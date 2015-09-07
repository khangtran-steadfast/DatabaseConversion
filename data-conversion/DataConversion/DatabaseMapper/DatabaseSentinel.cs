using DataConversion.DatabaseMapper.Snapshot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper
{
    /// <summary>
    /// This class is for validating data
    /// and checking duplicate data
    /// </summary>
    public class DatabaseSentinel
    {
        #region CONSTRUCTOR, INTIALIZE

        /// <summary>
        /// Create database sentinel
        /// </summary>
        public DatabaseSentinel()
        {
            this._listErrorTables = new List<string>();
            this._listTableToCheck = new List<string>();
        }

        /// <summary>
        /// Initialize DatabaseSentinel for sourceDatabase and destinationDatabase
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void Initialize(SourceDatabase source, DestinationDatabase destination)
        {
            //
            // Create database snapshot
            // To store record which has been mapped
            DatabaseSnapshot sourceDatabaseSnapshot = new DatabaseSnapshot(source);
            DatabaseSnapshot destDatabaseSnapshot = new DatabaseSnapshot(destination);


            //
            // Get all table of destination database
            // Validate source table, and destination table
            List<string> listTables = destination.GetListTableHasPrimaryKey();
            foreach (string table in listTables)
            {
                try
                {
                    this.Initialize(table, sourceDatabaseSnapshot, destDatabaseSnapshot, destDatabaseSnapshot);
                }
                catch (Exception excSaveSnapshot)
                {
                    LogService.Log.Error("Can not save snapshot of table " + table + ". Please check your schema again.", excSaveSnapshot);
                    Environment.Exit(0);
                }
            }


            //
            // Save snapshot
            this._databaseSnapshot = destDatabaseSnapshot;
        }

        /// <summary>
        /// Initialize hasMapped dictionary with tableName
        /// To determinate which record has been mapped
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        protected void Initialize(string tableName, DatabaseSnapshot sourceSnapshot, DatabaseSnapshot destSnapshot, DatabaseSnapshot outputSnapshot)
        {
            //TableSnapshot sourceTable = sourceSnapshot.GetTableSnapshot(tableName);
            TableSnapshot destTable = destSnapshot.GetTableSnapshot(tableName);

            ////
            //// Get common record from source table and destTable
            //// Then try to save to database
            //TableSnapshot commonTable = TableSnapshot.GetCommonRecord(sourceTable, destTable);
            //if (commonTable.IsEmpty == false)
            //{
            //    this._listTableToCheck.Add(tableName);
            //}
            if (destTable.IsEmpty == false)
            {
                this._listTableToCheck.Add(tableName);
            }

            //
            // Add
            outputSnapshot.Add(destTable);
            LogService.Log.Info("Saved snapshot of table : " + tableName);
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Add new record to database snapshot
        /// </summary>
        /// <param name="record"></param>
        public void Add(object record)
        {
            this._databaseSnapshot.AddRecord(record);
        }

        /// <summary>
        /// Add new snapshot to database snapshot
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        public void Add(string tableName, object record)
        {
            this._databaseSnapshot.Add(tableName, record);
        }

        /// <summary>
        /// Get TableSnapshot
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DatabaseSnapshot GetDatabaseSnapshot()
        {
            return this._databaseSnapshot;
        }

        /// <summary>
        /// Check record has been mapped or not
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool HasBeenMapped(string tableName, object record)
        {
            if (this._listTableToCheck.Contains(tableName))
            {
                return this._databaseSnapshot.Contains(tableName, record);
            }
            return false;
        }

        /// <summary>
        /// Check record has been mapped or not
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool HasBeenMapped(object record)
        {
            return this._databaseSnapshot.Contains(record);
        }

        /// <summary>
        /// Validate data between source and destination
        /// </summary>
        /// <param name="destinationDatabase"></param>
        /// <returns></returns>
        public bool ValidateData(SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            //
            // Initialize
            bool result = false;


            //
            // Get all table of destination database
            // Validate source table, and destination table
            List<string> listDestTables = destinationDatabase.GetListTable();
            bool validateTable = false;
            foreach (string destTable in listDestTables)
            {
                Console.WriteLine("------------");
                validateTable = this.ValidateData(destTable, sourceDatabase, destinationDatabase);
                if (validateTable)
                {
                    Console.WriteLine("Table name : " + destTable + " passed the test.");
                }
                else
                {
                    Console.WriteLine("Table name : " + destTable + " failed the test.");
                    result = false;
                }
            }



            //
            // Return result
            return result;
        }

        /// <summary>
        /// Validate data and write to file
        /// </summary>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool ValidateData(SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, string fileName)
        {
            //
            // Initialize
            bool result = false;
            StreamWriter writer = new StreamWriter(fileName);

            //
            // Get all table of destination database
            // Validate source table, and destination table
            List<string> listDestTables = destinationDatabase.GetListTable();
            bool validateTable = false;
            foreach (string destTable in listDestTables)
            {
                writer.WriteLine("------------");
                Console.WriteLine("------------");
                validateTable = this.ValidateData(destTable, sourceDatabase, destinationDatabase, writer);
                if (validateTable)
                {
                    writer.WriteLine("Table name : " + destTable + " passed the test.");
                    Console.WriteLine("Table name : " + destTable + " passed the test.");
                }
                else
                {
                    writer.WriteLine("Table name : " + destTable + " failed the test.");
                    Console.WriteLine("Table name : " + destTable + " failed the test.");
                    result = false;
                }
            }



            //
            // Return result
            writer.Close();
            return result;
        }

        /// <summary>
        /// Validate primary key and data of source, destination table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="destinationDatabase"></param>
        /// <returns></returns>
        public bool ValidateData(string tableName, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            //
            // Initialize result
            bool result = true;


            //
            // Get primary key values
            Dictionary<string, List<object>> destPKValues = destinationDatabase.GetListPrimaryKeyValue(tableName);
            Dictionary<string, List<object>> sourcePKValues = sourceDatabase.GetListPrimaryKeyValue(tableName);

            //
            // Try to validate number of primary key
            // If source table and destination table has different number of primary key
            if (destPKValues.Keys.Count != sourcePKValues.Keys.Count)
            {
                Console.WriteLine("Number of primary keys in source and destination table does not match.");
                return false;
            }



            //
            // Try to validate primary key names
            // Source table and destination table must have the same primary key's name
            foreach (string destPK in destPKValues.Keys.ToList())
            {
                if (sourcePKValues.ContainsKey(destPK) == false)
                {
                    Console.WriteLine("Destination table has primary key name : " + destPK + ", which does not exist in source table.");
                }
            }
            if (result == false)
            {
                return result;
            }



            //
            // Try to validate data
            foreach (string destPK in destPKValues.Keys.ToList())
            {
                List<object> sourceValues = sourcePKValues[destPK];
                List<object> destValues = destPKValues[destPK];
                foreach (object obj in destValues)
                {
                    if (sourceValues.Any(x => x.Equals(obj)) == false)
                    {
                        Console.WriteLine("Error, this primary does not exists in source database : " + obj);
                        result = false;
                    }
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Validate data and write to file
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public bool ValidateData(string tableName, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, StreamWriter writer)
        {
            //
            // Initialize result
            bool result = true;


            //
            // Get primary key values
            Dictionary<string, List<object>> destPKValues = destinationDatabase.GetListPrimaryKeyValue(tableName);
            Dictionary<string, List<object>> sourcePKValues = sourceDatabase.GetListPrimaryKeyValue(tableName);

            //
            // Try to validate number of primary key
            // If source table and destination table has different number of primary key
            if (destPKValues.Keys.Count != sourcePKValues.Keys.Count)
            {
                writer.WriteLine("Number of primary keys in source and destination table does not match.");
                return false;
            }



            //
            // Try to validate primary key names
            // Source table and destination table must have the same primary key's name
            foreach (string destPK in destPKValues.Keys.ToList())
            {
                if (sourcePKValues.ContainsKey(destPK) == false)
                {
                    writer.WriteLine("Destination table has primary key name : " + destPK + ", which does not exist in source table.");
                }
            }
            if (result == false)
            {
                return result;
            }



            //
            // Try to validate data
            foreach (string destPK in destPKValues.Keys.ToList())
            {
                List<object> sourceValues = sourcePKValues[destPK];
                List<object> destValues = destPKValues[destPK];
                foreach (object obj in destValues)
                {
                    if (sourceValues.Any(x => x.Equals(obj)) == false)
                    {
                        writer.WriteLine("Error, this primary key value does not exist in source database : " + obj);
                        result = false;
                    }
                }
            }


            //
            // Return result
            return result;
        }


        #endregion


        #region PROPERTIES


        /// <summary>
        /// Database snapshot, contain record which has been mapped
        /// </summary>
        protected DatabaseSnapshot _databaseSnapshot;

        /// <summary>
        /// List to store table has different number of primarykey
        /// Or different primarykey's name
        /// </summary>
        protected List<string> _listErrorTables;


        /// <summary>
        /// List table already has data and needs to check
        /// </summary>
        protected List<string> _listTableToCheck;


        #endregion
    }
}
