using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.MapperReport
{
    public class ReportTableExporter
    {
        protected static string TABLE_NAME = "{TABLE_NAME}";
        protected static string TABLE_START_TIME = "{TABLE_START_TIME}";
        protected static string TABLE_RUNNING_TIME = "{TABLE_RUNNING_TIME}";
        protected static string TABLE_STATUS = "{TABLE_STATUS}";
        protected static string TABLE_TOTAL_RECORDS = "{TABLE_TOTAL_RECORDS}";
        protected static string TABLE_ALREADY_EXISTED = "{TABLE_ALREADY_EXISTED}";
        protected static string TABLE_SUCCESS = "{TABLE_SUCCESS}";
        protected static string TABLE_EXCEPTION = "{TABLE_EXCEPTION}";
        protected static string TABLE_DETAIL = "{TABLE_DETAIL}";

        /// <summary>
        /// Get report and write to file
        /// </summary>
        /// <param name="reportTable"></param>
        /// <param name="filePath"></param>
        public static void GetReport(MapperReportTable reportTable, string filePath)
        {
            //
            // First get report
            string report = GetReport(reportTable);
            
            //
            // Then try write file
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine(report);
                writer.Close();
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not create StreamWriter for this file path : " + filePath, exc);
            }
        }

        /// <summary>
        /// Get report for mapping table
        /// </summary>
        /// <param name="reportTable"></param>
        /// <returns></returns>
        public static string GetReport(MapperReportTable reportTable)
        {
            //
            // Initialize
            string TEMPLATE = GetTemplate();
            string result = "";
            if (result == null)
            {
                result = "Can not get report template for table. Please try later.";
                return result;
            }


            //
            // Get information
            string tableName = reportTable.TableName;
            string tableStartTime = string.Format("{0:g}", reportTable.StartTime);
            string tableRunningTime = reportTable.RunningTime.ToString();
            string tableStatus = reportTable.GetStatus();
            string tableTotalRecords = reportTable.TotalRecord.ToString();
            string tableAlreadyExisted = reportTable.NumberOfAlreadyExisted.ToString();
            string tableSuccess = reportTable.NumberOfSuccess.ToString();
            string tableException = reportTable.NumberOfErrors.ToString();


            //
            // Get mapping detail
            string tableDetail = "";
            string exceptionTemplate = "<tr><td><b>{ROW_ID}</b></td><td>{EXCEPTION_MESSAGE}</td></tr>";
            int rowID = 0;
            foreach (string exceptionMessage in reportTable.ExceptionMessages)
            {
                rowID = rowID + 1;
                tableDetail = tableDetail + exceptionTemplate.Replace("{ROW_ID}", rowID.ToString())
                                                             .Replace("{EXCEPTION_MESSAGE}", exceptionMessage);
            }

            
            //
            // Compile
            result = TEMPLATE.Replace(TABLE_NAME, tableName)
                             .Replace(TABLE_START_TIME, tableStartTime)
                             .Replace(TABLE_RUNNING_TIME, tableRunningTime)
                             .Replace(TABLE_STATUS, tableStatus)
                             .Replace(TABLE_TOTAL_RECORDS, tableTotalRecords)
                             .Replace(TABLE_ALREADY_EXISTED, tableAlreadyExisted)
                             .Replace(TABLE_SUCCESS, tableSuccess)
                             .Replace(TABLE_EXCEPTION, tableException)
                             .Replace(TABLE_DETAIL, tableDetail);



            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get report template for table mapping
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
            string sourceFilePath = "DataConversion.DatabaseMapper.MapperReport.ReportTableTemplate.html";
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
                LogService.Log.Error("Can not get report template from file.", exc);
            }


            //
            // Return result
            return result;
        }
    }
}
