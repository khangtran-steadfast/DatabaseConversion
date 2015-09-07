using DataConversion.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.DataValidation.Orphan
{
    public class OrphanRecordValidationThreadManager
    {
        #region CONSTRUCTOR


        /// <summary>
        /// Create new orphan record validation manager
        /// </summary>
        /// <param name="database"></param>
        public OrphanRecordValidationThreadManager(SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            this._sourceDatabase = sourceDatabase;
            this._destinationDatabase = destinationDatabase;
            this._locker = new object();
            this.MaximumNumberOfThread = 60;
            this.MinimumTaskForThread = 10;
        }


        #endregion


        #region METHODS

        /// <summary>
        /// Validate table
        /// </summary>
        /// <param name="tableName"></param>
        public void Validate(string tableName)
        {
            //
            // Get DbSet
            DbSet dbSet = this._sourceDatabase.GetTable(tableName);
            if (dbSet == null)
            {
                return;
            }


            //
            // Get type accessor to access record's value
            TypeAccessor typeAccessor = this._sourceDatabase.GetTableTypeAccessor(tableName);
            if (typeAccessor == null)
            {
                return;
            }


            //
            // Get list reference of table
            List<ReferenceInformation> listReference = this._sourceDatabase.GetListReference(tableName);
            if (listReference.Count == 0)
            {
                return;
            }


            //
            // Load table into memory
            dbSet.Load();
            this._listTask = dbSet.Local;
            this._numberOfTask = this._listTask.Count;
            this._currentIndex = 0;
            LogService.Log.Info("Total records : " + this._numberOfTask.ToString());
            if (this._numberOfTask == 0)
            {
                return;
            }


            //
            // Calculate how many thread will we need
            int numberOfThreads = this.MaximumNumberOfThread;
            if (this._numberOfTask < numberOfThreads * this.MinimumTaskForThread)
            {
                numberOfThreads = this._numberOfTask / this.MinimumTaskForThread;
                if (numberOfThreads == 0)
                {
                    numberOfThreads = 1;
                }
            }


            //
            // Create thread and start
            LogService.Log.Info("Creating " + numberOfThreads.ToString() + " threads to validate.");
            this._threadHandler = new List<OrphanRecordValidationThread>();
            for (int counter = 0; counter < numberOfThreads; ++counter)
            {
                OrphanRecordValidationThread thread = new OrphanRecordValidationThread(this, this._sourceDatabase.GetNewDbContext(), 
                                                                                       tableName, typeAccessor, listReference);
                thread.Start();
                this._threadHandler.Add(thread);
            }


            //
            // Wait until done
            bool done = false;
            while (done == false)
            {
                done = true;
                foreach (OrphanRecordValidationThread thread in this._threadHandler)
                {
                    if (thread.IsDone == false)
                    {
                        done = false;
                        break;
                    }
                }
                LogService.Log.Info(this._currentIndex.ToString() + " / " + this._numberOfTask.ToString());
                System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Get task for thread;
        /// </summary>
        /// <returns></returns>
        public object GetTask()
        {
            //
            // Initialize result
            object result = null;

            //
            // Get task
            lock (this._locker)
            {
                if (this._currentIndex < this._numberOfTask)
                {
                    result = this._listTask[this._currentIndex];
                    this._currentIndex = this._currentIndex + 1;
                }
            }


            //
            // Return task
            return result;
        }

        /// <summary>
        /// Check out of task or not
        /// </summary>
        public bool IsOutOfTask
        {
            get
            {
                lock (this._locker)
                {
                    if (this._currentIndex < this._numberOfTask)
                        return false;
                    return true;
                }
            }
        }

        /// <summary>
        /// Maximum number of threads
        /// </summary>
        public int MaximumNumberOfThread { get; set; }

        /// <summary>
        /// Minimum task for each thread
        /// </summary>
        public int MinimumTaskForThread { get; set; }


        #endregion


        #region PROPERTIES

        /// <summary>
        /// Map database handler
        /// </summary>
        protected SourceDatabase _sourceDatabase;

        /// <summary>
        /// Destination database
        /// </summary>
        protected DestinationDatabase _destinationDatabase;

        /// <summary>
        /// List of task
        /// </summary>
        protected IList _listTask;

        /// <summary>
        /// Number of task
        /// </summary>
        protected int _numberOfTask;

        /// <summary>
        /// Current task index
        /// </summary>
        protected int _currentIndex;

        /// <summary>
        /// Locker, used when enter critical section
        /// </summary>
        protected object _locker;

        /// <summary>
        /// Thread handler
        /// </summary>
        protected List<OrphanRecordValidationThread> _threadHandler;


        #endregion
    }
}
