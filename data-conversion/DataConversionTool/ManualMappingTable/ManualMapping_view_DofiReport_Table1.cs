using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;
namespace DataConversionTool.ManualMappingTable
{
    public class ManualMapping_view_DofiReport_Table1 : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for view_DofiReport_Table1 table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_view_DofiReport_Table1()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for view_DofiReport_Table1
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
            string tableName = "view_DofiReport_Table1";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.view_DofiReport_Table1(spid, apra_authorised_during_reporting_period, apra_authorised_after_reporting_period, apra_authorised_before_reporting_period, lloyd_during_reporting_period, lloyd_after_reporting_period, lloyd_before_reporting_period, ufi_during_reporting_period, ufi_after_reporting_period, ufi_before_reporting_period, broker_during_reporting_period, broker_after_reporting_period, broker_before_reporting_period)" + Environment.NewLine +
                               "SELECT spid, apra_authorised_during_reporting_period, apra_authorised_after_reporting_period, apra_authorised_before_reporting_period, lloyd_during_reporting_period, lloyd_after_reporting_period, lloyd_before_reporting_period, ufi_during_reporting_period, ufi_after_reporting_period, ufi_before_reporting_period, broker_during_reporting_period, broker_after_reporting_period, broker_before_reporting_period FROM {SOURCE_DATABASE_NAME}.dbo.view_DofiReport_Table1" + Environment.NewLine;
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