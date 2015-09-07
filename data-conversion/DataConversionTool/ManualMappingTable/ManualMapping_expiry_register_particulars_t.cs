using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;
namespace DataConversionTool.ManualMappingTable
{
    public class ManualMapping_expiry_register_particulars_t : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for expiry_register_particulars_t table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_expiry_register_particulars_t()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for expiry_register_particulars_t
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
            string tableName = "expiry_register_particulars_t";


            //
            // Exec sql script to insert data
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.expiry_register_particulars_t(erp_pol_parent_id, erp_pol_particulars, erp_pol_id, erp_pol_sum_insured, erp_spid)" + Environment.NewLine +
                               "SELECT erp_pol_parent_id, erp_pol_particulars, erp_pol_id, erp_pol_sum_insured, erp_spid FROM {SOURCE_DATABASE_NAME}.dbo.expiry_register_particulars_t" + Environment.NewLine;
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