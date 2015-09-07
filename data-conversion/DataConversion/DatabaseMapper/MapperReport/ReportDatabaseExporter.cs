using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.MapperReport
{
    public class ReportDatabaseExporter
    {
        protected static string DATABASE_SOURCE_NAME = "{DATABASE_SOURCE_NAME}";
        protected static string DATABASE_DEST_NAME = "{DATABASE_DEST_NAME}";
        protected static string DATABASE_START_TIME = "{DATABASE_START_TIME}";
        protected static string DATABASE_RUNNING_TIME = "{DATABASE_RUNNING_TIME}";
        protected static string DATABASE_STATUS = "{DATABASE_STATUS}";
        protected static string DATABASE_TOTAL_TABLE = "{DATABASE_TOTAL_TABLE}";
        protected static string DATABASE_SUCCESS = "{DATABASE_SUCCESS}";
        protected static string DATABASE_FAILED = "{DATABASE_FAILED}";
        protected static string DATABASE_DETAIL = "{DATABASE_DETAIL}";

        /// <summary>
        /// Get report and write to file
        /// </summary>
        /// <param name="reportDatabase"></param>
        /// <param name="filePath"></param>
        public static void GetReport(MapperReportDatabase reportDatabase, string filePath)
        {
            //
            // Get report
            string report = GetReport(reportDatabase);

            //
            // Then try write file
            try {
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine(report);
                writer.Close();
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not create stream writer for this file path : " + filePath, exc);
            }
        }

        /// <summary>
        /// Get report
        /// </summary>
        /// <param name="reportDatabase"></param>
        /// <returns></returns>
        public static string GetReport(MapperReportDatabase reportDatabase)
        {
            //
            // Initialize
            string result = "";
            string TEMPLATE = GetTemplate();
            if (result == null)
            {
                result = "Can not get report template for database. Please try later.";
                return result;
            }


            //
            // Get information
            string databaseSourceName = reportDatabase.SourceDatabaseName;
            string databaseDestName = reportDatabase.DestinationDatabaseName;
            string databaseStartTime = string.Format("{0:g}", reportDatabase.StartTime);
            string databaseRunningTime = reportDatabase.RunningTime.ToString();
            string databaseStatus = reportDatabase.GetStatus();
            string databaseTotalTable = reportDatabase.NumberOfTotalTable.ToString();
            string databaseSuccess = reportDatabase.NumberOfSuccessTable.ToString();
            string databaseFailed = reportDatabase.NumberOfFailedTable.ToString();
            
            //
            // Get mapping detail
            string databaseDetail = "";
            string successRowTemplate = "<tr><td><b>{ROW_ID}</b></td><td>{TABLE_NAME}</td><td>Success</td><td><a href=\"{TABLE_NAME}.html\"><span class=\"glyphicon glyphicon-search\" aria-hidden=\"true\"></span></a></td></tr>";
            string errorRowTemplate = "<tr class=\"danger\"><td><b>{ROW_ID}</b></td><td>{TABLE_NAME}</td><td>Success</td><td><a href=\"{TABLE_NAME}.html\"><span class=\"glyphicon glyphicon-search\" aria-hidden=\"true\"></span></a></td></tr>";
            int rowID = 0;
            foreach (MapperReportTable table in reportDatabase.ListReportTable)
            {
                rowID = rowID + 1;
                if (table.IsSuccess)
                {
                    databaseDetail = databaseDetail + successRowTemplate.Replace("{ROW_ID}", rowID.ToString())
                                                                        .Replace("{TABLE_NAME}", table.TableName);
                }
                else
                {
                    databaseDetail = databaseDetail + errorRowTemplate.Replace("{ROW_ID}", rowID.ToString())
                                                                      .Replace("{TABLE_NAME}", table.TableName);
                }
            }

            //
            // Complie
            result = TEMPLATE.Replace(DATABASE_SOURCE_NAME, databaseSourceName)
                             .Replace(DATABASE_DEST_NAME, databaseDestName)
                             .Replace(DATABASE_START_TIME, databaseStartTime)
                             .Replace(DATABASE_RUNNING_TIME, databaseRunningTime)
                             .Replace(DATABASE_STATUS, databaseStatus)
                             .Replace(DATABASE_TOTAL_TABLE, databaseTotalTable)
                             .Replace(DATABASE_SUCCESS, databaseSuccess)
                             .Replace(DATABASE_FAILED, databaseFailed)
                             .Replace(DATABASE_DETAIL, databaseDetail);
            

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get report template for database mapping
        /// </summary>
        /// <returns></returns>
        public static string GetTemplate()
        {
            //
            // Initialize result
            string result = null;


            //
            // Get resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            string sourceFilePath = "DataConversion.DatabaseMapper.MapperReport.ReportDatabaseTemplate.html";
            try
            {
                Stream stream = assembly.GetManifestResourceStream(sourceFilePath);
                StreamReader streamReader = new StreamReader(stream);
                result = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not get report template from file", exc);
            }


            //
            // Return result
            return result;
        }
    }
}
