using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;

namespace DataConversionTool.ManualMappingTable
{
    class ManualMapping_tmpPortfolioAnalysis : ManualMapping
    {
        /// <summary>
        /// Create manual mapping for table tmpPortfolioAnalysis
        /// This class will take care all mapping process
        /// </summary>
        public ManualMapping_tmpPortfolioAnalysis()
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
            string tableName = "tmpPortfolioAnalysis";


            //
            // Exec sql script to insert data
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.tmpPortfolioAnalysis(GrpId, GrpName, SortName, Clientcount, TotalPolicies, Totalclients, Premiums, leviduties, Othercharges, bfees, comm, InvoiceTotal, spid, pol_sub_agent_fee_pay_net_gst, pol_sub_agent_comm_pay_net_gst, ccfees)" + Environment.NewLine +
                               "SELECT GrpId, GrpName, SortName, Clientcount, TotalPolicies, Totalclients, Premiums, leviduties, Othercharges, bfees, comm, InvoiceTotal, spid, pol_sub_agent_fee_pay_net_gst, pol_sub_agent_comm_pay_net_gst, ccfees FROM {SOURCE_DATABASE_NAME}.dbo.tmpPortfolioAnalysis" + Environment.NewLine;
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
