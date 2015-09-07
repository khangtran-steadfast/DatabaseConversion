using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using DataConversion.DatabaseMapper.BATFile;
using DataConversion.DatabaseMapper.Threading;
using System;
using System.Data.Entity;
using System.Collections;
namespace DataConversion.DatabaseMapper
{
    /// <summary>
    /// Class maintains mapping process
    /// </summary>
    public class MappingManager
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create new mapping manager for source database and destination database
        /// </summary>
        /// <param name="sourceDatabase">Source database handler</param>
        /// <param name="destinationDatabase">Destination database handler</param>
        public MappingManager(SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            this._configManualMapping = new Dictionary<string, ManualMapping>();
            this._configChangeName = new Dictionary<string, string>();
            this._sourceDatabase = sourceDatabase;
            this._destinationDatabase = destinationDatabase;
            this._listPostMigrationScript = new List<string>();
            this._listPreConversionScript = new List<string>();
            this._databaseSentinel = new DatabaseSentinel();
            this.MaximumNumberOfThread = 50;
            this.MinimumTaskForThread = 10;
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Add manual mapping function for specifies table
        /// </summary>
        /// <param name="table">Table name</param>
        /// <param name="manualMapping">Manual mapping function for table</param>
        public void AddManualMapping(string table, ManualMapping manualMapping)
        {
            if (this._configManualMapping.ContainsKey(table) == false)
            {
                this._configManualMapping.Add(table, manualMapping);
            }
        }

        /// <summary>
        /// Add post migration script to run after mapping
        /// </summary>
        /// <param name="filePath">File path to migration script</param>
        public void AddPostMigrationScript(string filePath)
        {
            this._listPostMigrationScript.Add(filePath);
        }
        
        /// <summary>
        /// Add pre conversion script to run in source database
        /// </summary>
        /// <param name="filePath"></param>
        public void AddPreConversionScript(string filePath)
        {
            this._listPreConversionScript.Add(filePath);
        }

        /// <summary>
        /// Configure for table has change their name
        /// </summary>
        /// <param name="oldName">Old table name (in source database)</param>
        /// <param name="newName">New table name (in destination database)</param>
        public void ChangeName(string oldName, string newName)
        {
            this._configChangeName.Add(oldName, newName);
        }

        /// <summary>
        /// Configure auto mapper profile
        /// </summary>
        /// <param name="autoMapperProfile">Auto Mapper Profile</param>
        public void ConfigAutoMapper(Profile autoMapperProfile)
        {
            LogService.Log.Info("Configuring AutoMapper profile. Profile name : " + autoMapperProfile.ProfileName);
            Mapper.Initialize(x => x.AddProfile(autoMapperProfile));
        }

        /// <summary>
        /// Does this table need manual mapping ?
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns></returns>
        private bool IsManualMapping(string tableName)
        {
            if (this._configManualMapping.ContainsKey(tableName))
                return true;
            return false;
        }

        /// <summary>
        /// Get manual mapping function
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns></returns>
        private ManualMapping GetManualMappingFunction(string tableName)
        {
            if (this._configManualMapping.ContainsKey(tableName))
                return this._configManualMapping[tableName];
            return null;
        }

        /// <summary>
        /// Get file path to store migration script for table
        /// </summary>
        /// <param name="tableName">Table name to be migrated</param>
        /// <returns></returns>
        public string GetFilePath(string tableName)
        {
            string result = null;
            if (this._directoryPath != null)
            {
                result = this._directoryPath + @"\" + tableName + ".sql";
            }
            return result;
        }

        /// <summary>
        /// Get new table name in destination database
        /// </summary>
        /// <param name="oldTableName">Old table name</param>
        /// <returns></returns>
        public string GetTableNewName(string oldTableName)
        {
            string result = oldTableName;
            if (this._configChangeName.ContainsKey(oldTableName))
            {
                result = this._configChangeName[oldTableName];
            }
            return result;
        }

        /// <summary>
        /// Get old table name
        /// </summary>
        /// <param name="newTableName">New table name</param>
        /// <returns></returns>
        public string GetTableOldName(string newTableName)
        {
            string result = newTableName;
            if (this._configChangeName.Any(x => x.Value.Equals(newTableName)))
            {
                result = this._configChangeName.First(x => x.Value.Equals(newTableName)).Key;
            }
            return result;
        }

        /// <summary>
        /// Get file path to BAT file
        /// </summary>
        /// <returns></returns>
        public string GetBATFilePath()
        {
            return this._batFileGenerator.FilePath;
        }
        
        /// <summary>
        /// Set directory path to store generated SQL script
        /// </summary>
        /// <param name="directoryPath"></param>
        public void SetDirectoryPath(string directoryPath)
        {
            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }
            this._directoryPath = directoryPath;
            this._batFileGenerator = new SQLBATGenerator(this._directoryPath + @"\Run.bat");
            this._batFileGenerator.EchoOff();
            this._batFileGenerator.PromptServerName();
        }

        /// <summary>
        /// Start map database from source to destination database
        /// </summary>
        public void Map()
        {
            //
            // Run pre-conversion script first
            LogService.Log.Info("Running pre-conversion script.");
            this.RunPreConversionScript(this._sourceDatabase);

            //
            // Initialize for DatabaseSentinel (checking duplicated data)
            // And DataConversionReflection
            LogService.Log.Info("Number of table in destination database : " + this._destinationDatabase.NumberOfTable.ToString());
            LogService.Log.Info("Creating snapshot of database.");
            this._databaseSentinel.Initialize(this._sourceDatabase, this._destinationDatabase);
            this._multiThreadManager = new MultiThreadManager(this, this._sourceDatabase, this._destinationDatabase, this._databaseSentinel, this.MaximumNumberOfThread, this.MinimumTaskForThread);
            this._sqlMultiThreadManager = new SQLMultiThreadingManager(this._destinationDatabase, this.MaximumNumberOfThread, this.MinimumTaskForThread);


            //
            // Ok, start map
            LogService.Log.Info("Start mapping.");
            while (this._destinationDatabase.IsCompleted() == false)
            {
                //
                // Get next table to map
                MapTable nextTable = this._destinationDatabase.NextTable();
                if (nextTable == null)
                {
                    LogService.Log.Error("Can not get next table to map. Please check circle references again.");
                    break;
                }                           


                //
                // Is manual mapping or auto mapping
                nextTable.Map();
                LogService.Log.Info("Start mapping " + nextTable.Name);
                try
                {
                    if (this.IsManualMapping(nextTable.Name))
                    {
                        this.MapManual(nextTable.Name);
                    }
                    else
                    {
                        this.MapAutomatically(nextTable.Name);
                    }
                }
                catch (Exception exc)
                {
                    LogService.Log.Error("Error occurs when mapping with table " + nextTable.Name, exc);
                }


                //
                // Append to batch file to run SQL script
                if (this.IsGeneratedScript)
                {
                    this._batFileGenerator.RunSQLFile(Path.GetFileName(this.GetFilePath(nextTable.Name)));
                }
            }


            //
            // Run post migration script
            this.RunPostMigrationScript(this._destinationDatabase);


            //
            // Report, done mapping
            if (this.IsGeneratedScript)
            {
                this._batFileGenerator.ShowMessage("Done.");
                this._batFileGenerator.EchoOn();
            }
            LogService.Log.Info("Mapping completed.");
        }

        /// <summary>
        /// Start manual mapping function
        /// </summary>
        /// <param name="tableName"></param>
        private void MapManual(string tableName)
        {
            //
            // Get manual mapping for table
            ManualMapping manualMapping = this._configManualMapping[tableName];


            //
            // If this table override all mapping process
            // Then invoke Map function only
            if (manualMapping.ManualMappingAllProcess)
            {
                try
                {
                    manualMapping.Map(this, this._sourceDatabase, this._destinationDatabase);
                    this._destinationDatabase.SaveChanges();
                }
                catch (Exception excManualMappingAllProcess)
                {
                    LogService.Log.Info("Error when mapping with " + tableName, excManualMappingAllProcess);
                }
            }
            else
            {
                manualMapping.BeforeMapping(this, this._sourceDatabase, this._destinationDatabase);

                //
                // Get mapping config
                // Which talble in source database will map with this table ?
                // By default, two table have the same name will be mapped
                string sourceTableName = this.GetTableOldName(tableName);


                //
                // Initialize for auto mapping
                DbSet sourceTable = this._sourceDatabase.GetTable(sourceTableName);
                DbSet destTable = this._destinationDatabase.GetTable(tableName);
                if (sourceTable == null)
                {
                    LogService.Log.Error("Can not get " + sourceTableName + " DbSet from source database.");
                    return;
                }
                if (destTable == null)
                {
                    LogService.Log.Error("Can not get " + tableName + " DbSet from destination database.");
                    return;
                }


                //
                // Load and count
                LogService.Log.Info("Loading table into memory.");
                sourceTable.Load();
                IList listRecords = sourceTable.Local;
                int totalRecord = listRecords.Count;
                LogService.Log.Info("Number of records : " + totalRecord.ToString());


                //
                // First, try to run automapper with multi threading
                LogService.Log.Info("Run AutoMapper with multi threading.");
                List<object> listNewRecord = this._multiThreadManager.RunAutoMapperMultiThread(listRecords, totalRecord, sourceTableName, tableName, sourceTable.ElementType, destTable.ElementType, manualMapping).ToList();


                //
                // Second, add new record to database, then save changes
                manualMapping.BeforeCommitChanges(this, this._sourceDatabase, this._destinationDatabase, listNewRecord.ToList());
                LogService.Log.Info("Inserting records to destination database.");
                if (this.IsGeneratedScript)
                {
                    string filePath = this.GetFilePath(tableName);
                    LogService.Log.Info("Generate migration script to file, file path : " + filePath);
                    this._sqlMultiThreadManager.Insert(listNewRecord, tableName, this._destinationDatabase.GetTableTypeAccessor(tableName), this._destinationDatabase.GetTableColumn(tableName), filePath);
                }
                else
                {
                    this._sqlMultiThreadManager.Insert(listNewRecord, tableName, this._destinationDatabase.GetTableTypeAccessor(tableName), this._destinationDatabase.GetTableColumn(tableName));
                }
                manualMapping.AfterCommitChanges(this, this._sourceDatabase, this._destinationDatabase);


                //
                // Done
                manualMapping.AfterMapping(this, this._sourceDatabase, this._destinationDatabase);
                LogService.Log.Info("Mapping " + tableName + " done.");
            }
        }
        
        /// <summary>
        /// Auto mapping function
        /// </summary>
        /// <param name="tableName"></param>
        private void MapAutomatically(string tableName)
        {
            //
            // Get mapping config
            // Which talble in source database will map with this table ?
            // By default, two table have the same name will be mapped
            string sourceTableName = this.GetTableOldName(tableName);


            //
            // Initialize for auto mapping
            LogService.Log.Info("Loading table into memory.");
            DbSet sourceTable = this._sourceDatabase.GetTable(sourceTableName);
            DbSet destTable = this._destinationDatabase.GetTable(tableName);
            sourceTable.Load();
            IList listRecords = sourceTable.Local;
            int totalRecord = listRecords.Count;


            //
            // First, try to run automapper with multi threading
            LogService.Log.Info("Total records : " + totalRecord);
            List<object> listNewRecord = this._multiThreadManager.RunAutoMapperMultiThread(listRecords, totalRecord, sourceTableName, tableName, sourceTable.ElementType, destTable.ElementType).ToList();


            //
            // Second, add new record to database, then save changes
            LogService.Log.Info("Inserting records to destination database.");
            if (this.IsGeneratedScript)
            {
                string filePath = this.GetFilePath(tableName);
                LogService.Log.Info("Generate migration script to file, file path : " + filePath);
                this._sqlMultiThreadManager.Insert(listNewRecord, tableName, this._destinationDatabase.GetTableTypeAccessor(tableName), this._destinationDatabase.GetTableColumn(tableName), filePath);
            }
            else
            {
                this._sqlMultiThreadManager.Insert(listNewRecord, tableName, this._destinationDatabase.GetTableTypeAccessor(tableName), this._destinationDatabase.GetTableColumn(tableName));
            }


            //
            // Done
            LogService.Log.Info("Mapping " + tableName + " done.");
        }

        /// <summary>
        /// Writer migration script for table to file
        /// </summary>
        /// <param name="tableName">Migrated table</param>
        /// <param name="script">Migration script</param>
        /// <param name="append">Append to file</param>
        public void WriteSQLScript(string tableName, string script, bool append)
        {
            //
            // Get filePath to store migration script
            // Then try to open stream writer
            string filePath = this.GetFilePath(tableName);
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath, append);
            }
            catch (Exception excOpenStreamWriter)
            {
                LogService.Log.Error("Can not open stream writer, file path : " + filePath, excOpenStreamWriter);
                return;
            }


            //
            // Writer migration script
            writer.Write(script);



            //
            // Close stream
            writer.Close();
        }
        
        /// <summary>
        /// Run pre-conversion script before mapping
        /// </summary>
        /// <param name="sourceDatabase"></param>
        private void RunPreConversionScript(SourceDatabase sourceDatabase)
        {
            foreach (string filePath in this._listPreConversionScript)
            {
                LogService.Log.Info("Run pre-conversion script before mapping : " + filePath);
                sourceDatabase.RunSQLScript(filePath);
            }
        }

        /// <summary>
        /// Run post migration script after mapping
        /// </summary>
        /// <param name="destinationDatabase"></param>
        private void RunPostMigrationScript(DestinationDatabase destinationDatabase)
        {
            foreach (string filePath in this._listPostMigrationScript)
            {
                //
                // Check we need to run it, or extract to output folder
                if (this.IsGeneratedScript)
                {
                    LogService.Log.Info("Generate post migration script from : " + filePath);
                    try
                    {
                        string newFilePath = this._directoryPath + @"\" + Path.GetFileName(filePath);
                        StreamReader reader = new StreamReader(filePath);
                        StreamWriter writer = new StreamWriter(newFilePath);
                        writer.WriteLine("USE " + destinationDatabase.GetDatabaseName());
                        writer.Write(reader.ReadToEnd());
                        writer.Flush();
                        writer.Close();
                        reader.Close();

                        //
                        // Write to batch file to execute this script
                        this._batFileGenerator.RunSQLFile(Path.GetFileName(newFilePath));
                    }
                    catch (Exception excExtractMigrationScript)
                    {
                        LogService.Log.Error("Can not generate post migration script from : " + filePath, excExtractMigrationScript);
                    }
                }
                else
                {
                    LogService.Log.Info("Run post migration script from : " + filePath);
                    destinationDatabase.RunSQLScript(filePath);
                }
            }
        }


        #endregion


        #region MEMBER, PROPERTIES


        /// <summary>
        /// Set, get maximum number of threads will be used while mapping
        /// </summary>
        public int MaximumNumberOfThread { get; set; }

        /// <summary>
        /// Get, set minimum task for single thread
        /// </summary>
        public int MinimumTaskForThread { get; set; }

        /// <summary>
        /// Check it executes SQL script or export SQL script to file
        /// </summary>
        public bool IsGeneratedScript
        {
            get
            {
                if (this._directoryPath == null)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Get directory path where SQL script is stored
        /// </summary>
        public string ExportPath
        {
            get
            {
                return this._directoryPath;
            }
        }
        
        /// <summary>
        /// Database sentinel
        /// </summary>  
        private DatabaseSentinel _databaseSentinel;

        /// <summary>
        /// Multi thread manager
        /// </summary>
        private MultiThreadManager _multiThreadManager;

        /// <summary>
        /// SQL Multi Thread manager
        /// </summary>
        private SQLMultiThreadingManager _sqlMultiThreadManager;

        /// <summary>
        /// Directory path where SQL script is stored
        /// </summary>
        private string _directoryPath;

        /// <summary>
        /// List post migration script to run after mapping
        /// </summary>
        public List<string> _listPostMigrationScript;

        /// <summary>
        /// List string contain file path to pre-conversion script
        /// </summary>
        public List<string> _listPreConversionScript;

        /// <summary>
        /// Generate batch file to execute SQL script
        /// </summary>
        private SQLBATGenerator _batFileGenerator;

        /// <summary>
        /// Dictionary to determinate which table has manual mapping function
        /// </summary>
        private Dictionary<string, ManualMapping> _configManualMapping;
        
        /// <summary>
        /// Dictionary to config for table has change their name
        /// </summary>
        private Dictionary<string, string> _configChangeName;

        /// <summary>
        /// Source database handler
        /// </summary>
        private SourceDatabase _sourceDatabase;

        /// <summary>
        /// Destination database handler
        /// </summary>
        private DestinationDatabase _destinationDatabase;


        #endregion
    }
}
