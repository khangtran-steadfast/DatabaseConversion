using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Data.Entity;
using System.Linq;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_view_earnings : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for view_earnings table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_view_earnings()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for view_earnings
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
            string tableName = "view_earnings";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.view_earnings(ent_id, ent_name, genins_name, pol_parent_id, pol_id, pol_tran_id, pol_total_gross_premium, pol_total_net_premium, adj, acr, debtor_bal, earn_broker_comm, earn_sa_comm, earn_broker_fee, earn_sa_fee, earn_total, spid, earn_gst, broker_comm, broker_fee, total_earn, comm_earned, fees_earned, fees_gst, comm_gst, total_earn_gst, total_earn_net_gst, gst_rate, bal, bal2, sa_payable, pol_amount_remitted_sub, sa_gst, pol_fee_gst, pol_comm_gst, debtor_paid, paid_date, br_comm_adjustment)" + Environment.NewLine +
                               "SELECT ent_id, ent_name, genins_name, pol_parent_id, pol_id, pol_tran_id, pol_total_gross_premium, pol_total_net_premium, adj, acr, debtor_bal, earn_broker_comm, earn_sa_comm, earn_broker_fee, earn_sa_fee, earn_total, spid, earn_gst, broker_comm, broker_fee, total_earn, comm_earned, fees_earned, fees_gst, comm_gst, total_earn_gst, total_earn_net_gst, gst_rate, bal, bal2, sa_payable, pol_amount_remitted_sub, sa_gst, pol_fee_gst, pol_comm_gst, debtor_paid, paid_date, br_comm_adjustment FROM {SOURCE_DATABASE_NAME}.dbo.view_earnings" + Environment.NewLine;
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