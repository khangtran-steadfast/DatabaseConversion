using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.MapperReport
{
    public class MapperReportManager
    {
        /// <summary>
        /// Create new mapping report manager
        /// </summary>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public MapperReportManager(string sourceDatabase, string destinationDatabase)
        {
            this._reportDatabase = new MapperReportDatabase(sourceDatabase, destinationDatabase);
        }
        
        /// <summary>
        /// Set export directory
        /// </summary>
        /// <param name="directoryPath"></param>
        public void SetExportDirectory(string directoryPath)
        {
            REPORT_FOLDER = directoryPath;
            if (Directory.Exists(REPORT_FOLDER) == false)
            {
                Directory.CreateDirectory(REPORT_FOLDER);
            }
        }

        /// <summary>
        /// Export report
        /// </summary>
        public void ExportReport()
        {
            //
            // First, try to export report for table first
            foreach (MapperReportTable table in this._reportDatabase.ListReportTable)
            {
                if (table.IsExported == false)
                {
                    ReportTableExporter.GetReport(table, REPORT_FOLDER + table.TableName + ".html");
                    table.IsExported = true;
                }
            }


            //
            // Then try to export report for database
            ReportDatabaseExporter.GetReport(this._reportDatabase, REPORT_FOLDER + "DatabaseReport.html");
        }

        /// <summary>
        /// Get mapping report for database
        /// </summary>
        public MapperReportDatabase ReportDatabase
        {
            get
            {
                return this._reportDatabase;
            }
        }
        
        /// <summary>
        /// Report for mapping database
        /// </summary>
        protected MapperReportDatabase _reportDatabase;

        /// <summary>
        /// Report folder
        /// </summary>
        protected static string REPORT_FOLDER = @"\MigrationReport\";
    }
}
