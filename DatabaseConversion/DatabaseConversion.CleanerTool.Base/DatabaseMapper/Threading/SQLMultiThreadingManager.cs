using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Threading
{
    public class SQLMultiThreadingManager
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create SQL Multi Threading manager
        /// </summary>
        /// <param name="connectionString"></param>
        public SQLMultiThreadingManager(DestinationDatabase destinationDatabase)
        {
            this._destinationDatabase = destinationDatabase;
            this._maxThread = 50;
            this._minTaskForThread = 20;
            this._locker = new object();
        }

        /// <summary>
        /// Create SQLMulti Threading manager
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="maxThread"></param>
        /// <param name="minTaskForThread"></param>
        public SQLMultiThreadingManager(DestinationDatabase destinationDatabase, int maxThread, int minTaskForThread)
        {
            this._destinationDatabase = destinationDatabase;
            this._maxThread = maxThread;
            this._minTaskForThread = minTaskForThread;
            this._locker = new object();
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Generate SQL script to insert
        /// </summary>
        /// <param name="listOfTasks">List of record need to be generated insert script</param>
        /// <param name="tableName">Table name</param>
        /// <param name="typeAccessor">Type accessor to access column value</param>
        /// <param name="listColumnInformation">Store column infomration of table</param>
        public void Insert(List<object> listOfTasks, string tableName, TypeAccessor typeAccessor, List<ColumnInformation> listColumnInformation)
        {
            //
            // Initialize
            this._listOfTasks = listOfTasks;
            this._numberOfTasks = this._listOfTasks.Count;
            this._currentIndex = 0;
            if (this._numberOfTasks == 0)
            {
                return;
            }
            

            //
            // Okay, calculate, how many thread do we need ?
            int numberOfThreads = this._maxThread;
            if (this._numberOfTasks < numberOfThreads * this._minTaskForThread)
            {
                numberOfThreads = this._numberOfTasks / this._minTaskForThread;
                if (numberOfThreads == 0)
                {
                    numberOfThreads = 1;
                }
            }

            //
            /// Tempory disable trigger
            this._destinationDatabase.GetNewDbContext().Database.ExecuteSqlCommand("ALTER TABLE " + tableName + " DISABLE TRIGGER ALL");

            //
            // Create thread
            LogService.Log.Info("Creating " + numberOfThreads.ToString() + " SQL threads to insert data.");
            this._listSQLThread = new List<SQLThread>();
            for (int counter = 0; counter < numberOfThreads; ++counter)
            {
                SQLThread sqlThread = new SQLThread(this, false);
                this._listSQLThread.Add(sqlThread);
                sqlThread.Insert(tableName, listColumnInformation, typeAccessor);
            }

            //
            // Wait until done
            bool isDone = false;
            while (isDone == false)
            {
                isDone = true;
                foreach(SQLThread sqlThread in this._listSQLThread)
                {
                    if (sqlThread.IsDone == false)
                    {
                        isDone = false;
                        break;
                    }
                }
            }

            //
            // Turn on trigger
            this._destinationDatabase.GetNewDbContext().Database.ExecuteSqlCommand("ALTER TABLE " + tableName + " ENABLE TRIGGER ALL");
        }

        /// <summary>
        /// Generate SQL script to insert
        /// </summary>
        /// <param name="listOfTasks">List of record need to be generated insert script</param>
        /// <param name="tableName">Table name</param>
        /// <param name="typeAccessor">Type accessor to access column value</param>
        /// <param name="listColumnInformation">Store column infomration of table</param>
        /// <param name="filePath">File path to store sql script</param>
        public void Insert(List<object> listOfTasks, string tableName, TypeAccessor typeAccessor, List<ColumnInformation> listColumnInformation, string filePath)
        {
            //
            // Initialize
            this._listOfTasks = listOfTasks;
            this._numberOfTasks = this._listOfTasks.Count;
            this._currentIndex = 0;
            if (this._numberOfTasks == 0)
            {
                //
                // Create dump file
                try
                {
                    StreamWriter writer = new StreamWriter(filePath);
                    writer.Close();
                }
                catch (Exception excCreateDumpFile)
                {
                    LogService.Log.Error("Can not create dump file to map " + tableName, excCreateDumpFile);
                }
                return;
            }


            //
            // Okay, calculate, how many thread do we need ?
            int numberOfThreads = this._maxThread;
            if (this._numberOfTasks < numberOfThreads * this._minTaskForThread)
            {
                numberOfThreads = this._numberOfTasks / this._minTaskForThread;
                if (numberOfThreads == 0)
                {
                    numberOfThreads = 1;
                }
            }


            //
            // Create thread
            LogService.Log.Info("Creating " + numberOfThreads.ToString() + " SQL threads to insert data.");
            this._listSQLThread = new List<SQLThread>();
            for (int counter = 0; counter < numberOfThreads; ++counter)
            {
                SQLThread sqlThread = new SQLThread(this, true);
                this._listSQLThread.Add(sqlThread);
                sqlThread.Insert(tableName, listColumnInformation, typeAccessor);
            }


            //
            // Wait until done
            bool isDone = false;
            while (isDone == false)
            {
                isDone = true;
                foreach (SQLThread sqlThread in this._listSQLThread)
                {
                    if (sqlThread.IsDone == false)
                    {
                        isDone = false;
                        break;
                    }
                }
            }


            //
            // Write sql script to file
            this.WriteSQLScript(tableName, filePath);
        }

        /// <summary>
        /// Get new db context
        /// </summary>
        /// <returns></returns>
        public DbContext GetNewDbContext()
        {
            DbContext result = this._destinationDatabase.GetNewDbContext();
            result.Configuration.ProxyCreationEnabled = false;
            result.Configuration.ValidateOnSaveEnabled = false;
            result.Configuration.AutoDetectChangesEnabled = false;
            result.Configuration.LazyLoadingEnabled = false;
            return result;
        }

        /// <summary>
        /// Get task
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
                if (this._currentIndex < this._numberOfTasks)
                {
                    result = this._listOfTasks[this._currentIndex];
                    this._currentIndex = this._currentIndex + 1;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Determinate table has identity column or not
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool HasIdentityColumn(string tableName)
        {
            //
            // Initialize result
            bool result = false;


            //
            // Check
            try
            {
                DbContext dbContext = this.GetNewDbContext();
                string sqlScript = @"IF EXISTS ( SELECT * from syscolumns where id = Object_ID('{TABLE_NAME}') and colstat & 1 = 1 )
                                        SELECT 1
                                     ELSE
                                        SELECT 0".Replace("{TABLE_NAME}", tableName);
                Int32 response = dbContext.Database.SqlQuery<Int32>(sqlScript).FirstOrDefault();
                if (response == 1)
                {
                    result = true;
                }
            }
            catch (Exception excCheckIdentityColumn)
            {
                LogService.Log.Error("Can not check this table has identity column or not, table : " + tableName, excCheckIdentityColumn);
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Write generated sql script to file
        /// </summary>
        /// <param name="filePath"></param>
        private void WriteSQLScript(string tableName, string filePath)
        {
            //
            // First, try to open stream writer
            string sqlTurnOnIdentity = "SET IDENTITY_INSERT " + tableName + " ON" + Environment.NewLine;
            string sqlTurnOffIdentity = "SET IDENTITY_INSERT " + tableName + " OFF" + Environment.NewLine;
            string sqlTurnOffTrigger = "ALTER TABLE " + tableName + " DISABLE TRIGGER ALL" + Environment.NewLine;
            string sqlTurnOnTrigger = "ALTER TABLE " + tableName + " ENABLE TRIGGER ALL" + Environment.NewLine;
            bool hasIdentityColumn = this.HasIdentityColumn(tableName);
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath, false, Encoding.ASCII);
            }
            catch (Exception excWriteSQLToFile)
            {
                LogService.Log.Error("Can not write sql script to file. Table : " + tableName + ", file path : " + filePath, excWriteSQLToFile);
                return;
            }

            
            //
            // First, turn off trigger
            writer.WriteLine("USE [" + this._destinationDatabase.GetDatabaseName() + "]");
            writer.WriteLine("GO");
            writer.Write(sqlTurnOffTrigger);


            //
            // Check we need to turn off identity insert or not ?
            if (hasIdentityColumn)
            {
                writer.Write(sqlTurnOnIdentity);
            }
            
            
            //
            // Writer generated script
            foreach (SQLThread sqlThread in this._listSQLThread)
            {
                writer.Write(sqlThread.GetGeneratedScript());
            }


            //
            // Check we need to turn on identity insert or not ?
            if (hasIdentityColumn)
            {
                writer.Write(sqlTurnOffIdentity);
            }


            //
            // Turn on trigger
            writer.Write(sqlTurnOnTrigger);
            writer.Close();
        }


        #endregion


        #region PROPERTIES

        
        /// <summary>
        /// Maximum number of thread
        /// </summary>
        public int MaxThread
        {
            get
            {
                return this._maxThread;
            }
        }

        /// <summary>
        /// Minimum number of task for single thread
        /// </summary>
        public int MinTaskForThread
        {
            get
            {
                return this._minTaskForThread;
            }
        }

        /// <summary>
        /// Out of task
        /// </summary>
        public bool OutOfTask
        {
            get
            {
                lock (this._locker)
                {
                    return (this._currentIndex >= this._numberOfTasks);
                }
            }
            
        }

        /// <summary>
        /// Destination database hanlder
        /// </summary>
        private DestinationDatabase _destinationDatabase;

        /// <summary>
        /// List handler SQL Thread
        /// </summary>
        private List<SQLThread> _listSQLThread;

        /// <summary>
        /// Number of tasks
        /// </summary>
        private int _numberOfTasks;

        /// <summary>
        /// Current index to access task
        /// </summary>
        private int _currentIndex;

        /// <summary>
        /// Locker to access critical section
        /// </summary>
        private object _locker;
        
        /// <summary>
        /// Number of maximum thread
        /// </summary>
        private int _maxThread;

        /// <summary>
        /// Minimum task for thread
        /// </summary>
        private int _minTaskForThread;

        /// <summary>
        /// List of tasks
        /// </summary>
        private List<object> _listOfTasks;


        #endregion
    }
}
