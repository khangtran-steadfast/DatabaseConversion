using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.Threading
{
    public class AutoMapperThread
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create auto mapper thread
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="multiThreadMapper"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="databaseSentinel"></param>
        /// <param name="sourceTableName"></param>
        /// <param name="destTableName"></param>
        /// <param name="sourceTableType"></param>
        /// <param name="destTableType"></param>
        public AutoMapperThread(MappingManager manager,
                                MultiThreadManager multiThreadMapper,
                                SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, DatabaseSentinel databaseSentinel,
                                string sourceTableName, string destTableName, Type sourceTableType, Type destTableType)
        {
            this._multiThreadMapper = multiThreadMapper;
            this._sourceDatabase = sourceDatabase;
            this._destinationDatabase = destinationDatabase;
            this._databaseSentinel = databaseSentinel;
            this._destTableType = destTableType;
            this._sourceTableType = sourceTableType;
            this._sourceTableName = sourceTableName;
            this._destTableName = destTableName;
            this._manualMapping = null;
            this._sourceDatabase = null;
        }


        /// <summary>
        /// Create auto mapper thread
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="multiThreadMapper"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="databaseSentinel"></param>
        /// <param name="sourceTableName"></param>
        /// <param name="destTableName"></param>
        /// <param name="sourceTableType"></param>
        /// <param name="destTableType"></param>
        /// <param name="manualMapping"></param>
        public AutoMapperThread(MappingManager manager,
                                MultiThreadManager multiThreadMapper, 
                                SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, DatabaseSentinel databaseSentinel,
                                string sourceTableName, string destTableName, Type sourceTableType, Type destTableType, ManualMapping manualMapping)
        {
            this._multiThreadMapper = multiThreadMapper;
            this._sourceDatabase = sourceDatabase;
            this._destinationDatabase = destinationDatabase;
            this._databaseSentinel = databaseSentinel;
            this._sourceTableName = sourceTableName;
            this._destTableType = destTableType;
            this._sourceTableType = sourceTableType;
            this._destTableName = destTableName;
            this._manualMapping = manualMapping;
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Start thread
        /// </summary>
        public void Start()
        {
            try
            {
                this._threadHandler = new Thread(MapThread);
                this._threadHandler.Start();
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not create new thread.", exc);
                this._isDone = true;
            }
        }

        /// <summary>
        /// Full automatic thread
        /// </summary>
        protected void MapThread()
        {
            if (this._manualMapping == null)
            {
                MapAutomaticThread();
            }
            else
            {
                MapManualThread();
            }
        }

        /// <summary>
        /// Map function with full automatic mapping
        /// </summary>
        protected void MapAutomaticThread()
        {
            //
            // Set status
            this._isDone = false;

            //
            // Map
            while (this._multiThreadMapper.IsDone() == false)
            {
                //
                // Pick new task
                object task = this._multiThreadMapper.GetTask();


                //
                // Check again
                if (task == null)
                {
                    continue;
                }


                //
                // Use Auto mapper to map from source class to destination class
                object record = null;
                try
                {
                    record = Mapper.Map(task, this._sourceTableType, this._destTableType);
                }
                catch (Exception excAutoMapper)
                {
                    string message = "";
                    Dictionary<string, object> primaryKeyValues = this._sourceDatabase.GetPrimaryKeyValue(this._sourceTableName, task);
                    foreach (string primaryKey in primaryKeyValues.Keys)
                    {
                        message = message + primaryKey + " = " + primaryKeyValues[primaryKey].ToString();
                    }
                    LogService.Log.Error(message, excAutoMapper);
                    continue;
                }


                //
                // Update reference and save changes
                if (this._databaseSentinel.HasBeenMapped(this._destTableName, record) == false)
                {
                    this._multiThreadMapper.DoneTask(record);
                }
            }

            //
            // Change status
            this._isDone = true;
        }

        /// <summary>
        /// Manual thread
        /// </summary>
        protected void MapManualThread()
        {
            //
            // Set status
            this._isDone = false;

            //
            // Map
            while (this._multiThreadMapper.IsDone() == false)
            {
                //
                // Pick new task
                object task = this._multiThreadMapper.GetTask();


                //
                // Check again
                if (task == null)
                {
                    continue;
                }


                //
                // Ok, then map from original class to new class
                this._manualMapping.BeforeRunningAutoMapper(this._manager, this._sourceDatabase, this._destinationDatabase, task);
                object record = Mapper.Map(task, this._sourceTableType, this._destTableType);
                if (this._databaseSentinel.HasBeenMapped(this._destTableName, record) == false)
                {
                    //
                    // Exec manual function before mapping single record
                    this._manualMapping.BeforeMappingRecord(this._manager, this._sourceDatabase, this._destinationDatabase, record);
                    

                    //
                    // Exec manual function after mapping single record
                    this._manualMapping.AfterMappingRecord(this._manager, this._sourceDatabase, this._destinationDatabase, record);


                    //
                    // Clone and and return to main thread
                    this._multiThreadMapper.DoneTask(record);
                }
            }

            //
            // Change status
            this._isDone = true;
        }

        #endregion


        #region PROPERTIES


        /// <summary>
        /// Is Done or not ?
        /// </summary>
        public bool IsDone
        {
            get
            {
                return this._isDone;
            }
        }

        /// <summary>
        /// Mapping manager
        /// </summary>
        protected MappingManager _manager;

        /// <summary>
        /// MultiThreadMapper handler
        /// For requesting task
        /// </summary>
        protected MultiThreadManager _multiThreadMapper;

        /// <summary>
        /// Source database
        /// </summary>
        protected SourceDatabase _sourceDatabase;

        /// <summary>
        /// Destination database handler
        /// </summary>
        protected DestinationDatabase _destinationDatabase;
        
        /// <summary>
        /// Database sentinel
        /// </summary>
        protected DatabaseSentinel _databaseSentinel;

        /// <summary>
        /// Manual mapping
        /// </summary>
        protected ManualMapping _manualMapping;

        /// <summary>
        /// Source table name
        /// </summary>
        protected string _sourceTableName;

        /// <summary>
        /// Destination table name
        /// </summary>
        protected string _destTableName;

        /// <summary>
        /// Source table type
        /// </summary>
        protected Type _sourceTableType;

        /// <summary>
        /// Destination table type
        /// </summary>
        protected Type _destTableType;

        /// <summary>
        /// Thread handler
        /// </summary>
        protected Thread _threadHandler;

        /// <summary>
        /// Is Done
        /// </summary>
        protected bool _isDone;


        #endregion
    }
}