using AutoMapper;
using DataConversion.DatabaseMapper.MapperReport;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace DataConversion.DatabaseMapper.Threading
{
    public class MultiThreadManager
    {
        #region CONSTRUCTOR, INITIALIZE
        
        
        /// <summary>
        /// Create multi threading mapper
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="databaseSentinel"></param>
        /// <param name="maxThread"></param>
        /// <param name="minTaskForThread"></param>
        public MultiThreadManager(MappingManager manager,
                                  SourceDatabase sourceDatabase,
                                  DestinationDatabase destinationDatabase,
                                  DatabaseSentinel databaseSentinel, 
                                  int maxThread,
                                  int minTaskForThread)
        {
            this._manager = manager;
            this._sourceDatabase = sourceDatabase;
            this._destinationDatabase = destinationDatabase;
            this._databaseSentinel = databaseSentinel;
            this._maxSubThread = maxThread;
            this._minTaskForThread = minTaskForThread;
            this._locker = new object();
        }
        
        
        #endregion


        #region METHODS
                
        /// <summary>
        /// Run auto mapper with multi threadings
        /// </summary>
        /// <returns></returns>
        public SynchronizedCollection<object> RunAutoMapperMultiThread(IList listRecord,
                                                           int numberOfRecord,
                                                           string sourceTableName,
                                                           string destTableName,
                                                           Type sourceTableType,
                                                           Type destTableType)
        {
            //
            // Initialize
            // Calculate, how many thread will we need ?
            // At least, the minimum value for each thread is
            // 100 records / 1 thread
            // Cause we don't want to create too much thread
            this._listNewRecord = new SynchronizedCollection<object>();
            this._listRecord = listRecord;
            this._currentIndex = 0;
            this._numberOfRecords = numberOfRecord;
            int numberOfThread = this._maxSubThread;
            if (this._numberOfRecords == 0)
            {
                return this._listNewRecord;
            }
            if (this._numberOfRecords < this._maxSubThread * this._minTaskForThread)
            {
                numberOfThread = this._numberOfRecords / this._minTaskForThread;
                if (numberOfThread == 0)
                {
                    numberOfThread = 1;
                }
            }


            //
            // Start main sub thread
            // To map from source to destination database first
            int counter = 0;
            bool isDone = false;
            this._listAutoMapperThread = new List<AutoMapperThread>();
            for (counter = 0; counter < numberOfThread; ++counter)
            {
                AutoMapperThread autoMapperThread = new AutoMapperThread(this._manager, this, 
                                                                         this._sourceDatabase, this._destinationDatabase, this._databaseSentinel,
                                                                         sourceTableName, destTableName, sourceTableType, destTableType);
                autoMapperThread.Start();
                this._listAutoMapperThread.Add(autoMapperThread);
            }


            //
            // Loop, wait until done
            while (isDone == false)
            {
                isDone = true;
                foreach (AutoMapperThread autoMapperThread in this._listAutoMapperThread)
                {
                    if (autoMapperThread.IsDone == false)
                    {
                        isDone = false;
                        break;
                    }
                }
                LogService.Log.Info(this._currentIndex + " / " + this._numberOfRecords);
                System.Threading.Thread.Sleep(1000);
            }


            //
            // Return result
            return this._listNewRecord;
        }

        public SynchronizedCollection<object> RunAutoMapperMultiThread(IList listRecord,
                                                           int numberOfRecord,
                                                           string sourceTableName,
                                                           string destTableName,
                                                           Type sourceTableType,
                                                           Type destTableType,
                                                           ManualMapping manualMapping)
        {
            //
            // Initialize
            // Calculate, how many thread will we need ?
            // At least, the minimum value for each thread is
            // 100 records / 1 thread
            // Cause we don't want to create too much thread
            this._listNewRecord = new SynchronizedCollection<object>();
            this._listRecord = listRecord;
            this._currentIndex = 0;
            this._numberOfRecords = numberOfRecord;
            int numberOfThread = this._maxSubThread;
            if (this._numberOfRecords == 0)
            {
                return this._listNewRecord;
            }
            if (this._numberOfRecords < this._maxSubThread * this._minTaskForThread)
            {
                numberOfThread = this._numberOfRecords / this._minTaskForThread;
                if (numberOfThread == 0)
                {
                    numberOfThread = 1;
                }
            }


            //
            // Start main sub thread
            // To map from source to destination database first
            int counter = 0;
            bool isDone = false;
            this._listAutoMapperThread = new List<AutoMapperThread>();
            for (counter = 0; counter < numberOfThread; ++counter)
            {
                AutoMapperThread autoMapperThread = new AutoMapperThread(this._manager, this,
                                                                         this._sourceDatabase, this._destinationDatabase, this._databaseSentinel,
                                                                         sourceTableName, destTableName, sourceTableType, destTableType, manualMapping);
                this._listAutoMapperThread.Add(autoMapperThread);
                autoMapperThread.Start();
            }


            //
            // Loop, wait until done
            while (isDone == false)
            {
                isDone = true;
                foreach (AutoMapperThread autoMapperThread in this._listAutoMapperThread)
                {
                    if (autoMapperThread.IsDone == false)
                    {
                        isDone = false;
                        break;
                    }
                }
                LogService.Log.Info(this._currentIndex + " / " + this._numberOfRecords);
                System.Threading.Thread.Sleep(1000);
            }


            //
            // Return result
            return this._listNewRecord;
        }

        /// <summary>
        /// Get record to map
        /// </summary>
        /// <returns></returns>
        public object GetTask()
        {
            //
            // Initialize result
            object result = null;

            //
            // Check
            lock (this._locker)
            {
                if (this._currentIndex < this._numberOfRecords)
                {
                    result = this._listRecord[this._currentIndex];
                    this._currentIndex = this._currentIndex + 1;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Done with task
        /// </summary>
        /// <param name="recordChange"></param>
        public void DoneTask(object newRecord)
        {
            this._listNewRecord.Add(newRecord);
        }
                      
        /// <summary>
        /// Is mapping done or not
        /// </summary>
        /// <returns></returns>
        public bool IsDone()
        {
            return !(this._currentIndex < this._numberOfRecords);
        }

        /// <summary>
        /// Check reflection task is done or not
        /// </summary>
        /// <returns></returns>
        public bool IsDoneReflectionTask()
        {
            return (this._currentIndex >= this._listRecordChangeCount); 
        }


        #endregion


        #region PROPERTIES

        /// <summary>
        /// Mapping manager
        /// </summary>
        protected MappingManager _manager;

        /// <summary>
        /// Source database handler
        /// </summary>
        protected SourceDatabase _sourceDatabase;

        /// <summary>
        /// Destination database
        /// </summary>
        protected DestinationDatabase _destinationDatabase;

        /// <summary>
        /// The sentinel to check which data has been mapped
        /// </summary>
        protected DatabaseSentinel _databaseSentinel;

        /// <summary>
        /// List auto mapper thread handler
        /// </summary>
        protected List<AutoMapperThread> _listAutoMapperThread;

        /// <summary>
        /// List handler to new record
        /// </summary>
        protected SynchronizedCollection<object> _listNewRecord;

        /// <summary>
        /// 
        /// </summary>
        protected IList _listRecord;

        /// <summary>
        /// Number of records
        /// </summary>
        protected int _numberOfRecords;

        /// <summary>
        /// Locker - flag to access to critical section
        /// (multithreading problem)
        /// </summary>
        protected object _locker;

        /// <summary>
        /// Number elements of list record change count
        /// </summary>
        protected int _listRecordChangeCount;

        /// <summary>
        /// Current index of record to map
        /// </summary>
        protected int _currentIndex;

        /// <summary>
        /// Number of maximum sub thread
        /// </summary>
        protected int _maxSubThread;

        /// <summary>
        /// Minimum task for thread
        /// </summary>
        protected int _minTaskForThread;


        #endregion
    }
}