using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;
namespace DataConversionTool.ManualMappingTable
{
    public class ManualMapping_period_renewals_particulars_t : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for period_renewals_particulars_t table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_period_renewals_particulars_t()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for period_renewals_particulars_t
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
            string tableName = "period_renewals_particulars_t";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.period_renewals_particulars_t(prp_pol_parent_id, prp_pol_particulars, prp_pol_id, prp_pol_sum_insured, prp_spid)" + Environment.NewLine +
                               "SELECT prp_pol_parent_id, prp_pol_particulars, prp_pol_id, prp_pol_sum_insured, prp_spid FROM {SOURCE_DATABASE_NAME}.dbo.period_renewals_particulars_t" + Environment.NewLine;
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