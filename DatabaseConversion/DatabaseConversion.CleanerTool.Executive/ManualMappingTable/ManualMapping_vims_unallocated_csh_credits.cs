using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Data.Entity;
using System.Linq;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_vims_unallocated_csh_credits : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for vims_unallocated_csh_credits table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_vims_unallocated_csh_credits()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for vims_unallocated_csh_credits
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
            string tableName = "vims_unallocated_csh_credits";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.vims_unallocated_csh_credits(ent_id, insured_name, prof_sales_team, prof_service_team, insurer, sub_agent, bal_tran_id, tran_time, tran_type, particulars, bal_amount, sertea_name, saltea_name, insurer_name, sub_agent_name, spid)" + Environment.NewLine +
                               "SELECT ent_id, insured_name, prof_sales_team, prof_service_team, insurer, sub_agent, bal_tran_id, tran_time, tran_type, particulars, bal_amount, sertea_name, saltea_name, insurer_name, sub_agent_name, spid FROM {SOURCE_DATABASE_NAME}.dbo.vims_unallocated_csh_credits" + Environment.NewLine;
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