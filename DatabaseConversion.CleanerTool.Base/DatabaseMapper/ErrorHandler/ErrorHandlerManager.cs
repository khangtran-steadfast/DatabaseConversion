using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.ErrorHandler
{
    public enum ErrorType
    {
        Orphan,
        Unknown
    }
    /// <summary>
    /// This class provide the way to delete, update and re-add error record
    /// </summary>
    public class ErrorHandlerManager
    {
        /// <summary>
        /// Initialize for error handler manager
        /// </summary>
        static ErrorHandlerManager()
        {
            _listErrorRecords = new SynchronizedCollection<ErrorRecord>();
        }

        /// <summary>
        /// Add new error record
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        /// <param name="type"></param>
        public static void AddError(string tableName, object record, ErrorType type)
        {
            _listErrorRecords.Add(new ErrorRecord(tableName, record, type));
        }

        /// <summary>
        /// Add new error record
        /// </summary>
        /// <param name="errorRecord"></param>
        public static void AddError(ErrorRecord errorRecord)
        {
            _listErrorRecords.Add(errorRecord);
        }

        /// <summary>
        /// Export SQL Script to delete orphan record
        /// </summary>
        /// <param name="database"></param>
        /// <param name="filePath"></param>
        public static void ExportScriptToDeleteOrphan(MapDatabase database, string filePath)
        {
            //
            // Initialize
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath);
            }
            catch (Exception excCreateStream)
            {
                LogService.Log.Error("Can not create stream writer at " + filePath, excCreateStream);
                return;
            }



            //
            // Write out
            string databaseName = database.GetDatabaseName();
            writer.WriteLine("USE [" + database.GetDatabaseName() + "]");
            writer.WriteLine("GO");
            foreach (ErrorRecord error in _listErrorRecords)
            {
                if (error.Type == ErrorType.Orphan)
                {
                    string script = GenerateDeleteScript(database, databaseName, error);
                    writer.WriteLine(script);
                    writer.WriteLine("GO");
                }
            }


            //
            // Clean
            writer.Close();
        }

        /// <summary>
        /// Export script to delete orphaned record
        /// </summary>
        /// <param name="filePath"></param>
        public static void ExportScriptToDeleteOrphan(SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, string filePath)
        {
            //
            // Initialize
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath);
            }
            catch (Exception excCreateStream)
            {
                LogService.Log.Error("Can not create stream writer at " + filePath, excCreateStream);
                return;
            }



            //
            // Write out
            writer.WriteLine("USE [" + sourceDatabase.GetDatabaseName() + "]");
            writer.WriteLine("GO");
            foreach (ErrorRecord error in _listErrorRecords)
            {
                if (error.Type == ErrorType.Orphan)
                {
                    string script = GenerateDeleteScript(destinationDatabase, sourceDatabase.GetDatabaseName(), error);
                    writer.WriteLine(script);
                    writer.WriteLine("GO");
                }
            }


            //
            // Clean
            writer.Close();
        }

        /// <summary>
        /// Generate SQL script to delete this record
        /// </summary>
        /// <param name="database"></param>
        protected static string GenerateDeleteScript(MapDatabase database, string databaseName, ErrorRecord error)
        {
            //
            // Initialize result
            string result = "";
            string TEMPLATE = "DELETE FROM {DATABASE_NAME}.dbo.{TABLE_NAME} WHERE {PRIMARY_KEY_CONDITION}";
            string DATABASE_NAME = databaseName;
            string TABLE_NAME = error.TableName;
            string PRIMARY_KEY_CONDITION = "";

            //
            // Get neccessary information
            bool firstPrimaryKey = true;
            Dictionary<string, object> primaryKeys = database.GetPrimaryKeyValue(error.TableName, error.Record);
            foreach (string primaryKey in primaryKeys.Keys)
            {
                //
                // Get primary key value as string
                object objPrimaryKeyValue = primaryKeys[primaryKey];
                string strPrimaryKeyValue = "";
                if (objPrimaryKeyValue is string)
                {
                    strPrimaryKeyValue = "'" + objPrimaryKeyValue + "'";
                }
                else
                {
                    strPrimaryKeyValue = objPrimaryKeyValue.ToString();
                }


                //
                // Add to PRIMARY_KEY_CONDITION
                if (firstPrimaryKey)
                {
                    firstPrimaryKey = false;
                    PRIMARY_KEY_CONDITION = primaryKey + " = " + strPrimaryKeyValue;
                }
                else
                {
                    PRIMARY_KEY_CONDITION = PRIMARY_KEY_CONDITION + ", " + primaryKey + " = " + strPrimaryKeyValue;
                }
            }



            //
            // Return result
            result = TEMPLATE.Replace("{DATABASE_NAME}", DATABASE_NAME)
                             .Replace("{TABLE_NAME}", TABLE_NAME)
                             .Replace("{PRIMARY_KEY_CONDITION}", PRIMARY_KEY_CONDITION);
            return result;
        }

        /// <summary>
        /// List error records
        /// </summary>
        protected static SynchronizedCollection<ErrorRecord> _listErrorRecords;
    }
}
