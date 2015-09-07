using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;

namespace DataConversionTool.ManualMappingTable
{
    class ManualMapping_PaidInvoices : ManualMapping
    {
        /// <summary>
        /// Create manual mapping for table PaidInvoices
        /// This class will take care all mapping process
        /// </summary>
        public ManualMapping_PaidInvoices()
            : base(true)
        {

        }

        /// <summary>
        /// Main mapping function
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public override void Map(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            //
            // Try to get source database name and destination database name
            DbContext sourceDbContext = sourceDatabase.GetDbContext();
            DbContext destDbContext = destinationDatabase.GetDbContext();
            string sourceDatabaseName = sourceDbContext.Database.SqlQuery<string>(@"SELECT DB_NAME() AS [Current Database]").FirstOrDefault();
            string destDatabaseName = destDbContext.Database.SqlQuery<string>(@"SELECT DB_NAME() AS [Current Database]").FirstOrDefault();
            string tableName = "PaidInvoices";


            //
            // Exec sql script to insert data
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.PaidInvoices(tritm_tran_id, tritm_amount, Paid, Remaining, tritm_inc_id, DatePaid, spid)" + Environment.NewLine +
                               "SELECT tritm_tran_id, tritm_amount, Paid, Remaining, tritm_inc_id, DatePaid, spid FROM {SOURCE_DATABASE_NAME}.dbo.PaidInvoices" + Environment.NewLine;
            sqlQuery = sqlQuery.Replace("{SOURCE_DATABASE_NAME}", sourceDatabaseName)
                               .Replace("{DESTINATION_DATABASE_NAME}", destDatabaseName);


            //
            // Exec SQL script or write to file
            if (manager.IsGeneratedScript)
            {
                sqlQuery = "USE [" + destDatabaseName + "]" + Environment.NewLine +
                           "GO" + Environment.NewLine +
                           sqlQuery;
                manager.WriteSQLScript(tableName, sqlQuery, false);
            }
            else
            {
                try
                {
                    destDbContext.Database.ExecuteSqlCommand(sqlQuery);
                }
                catch (Exception excExecScript)
                {
                    LogService.Log.Error("Can not run migration script for " + tableName, excExecScript);
                }
            }
        }
    }
}
