using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Data.Entity;
using System.Linq;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_view_inspay : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for view_inspay table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_view_inspay()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for view_inspay
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
            string tableName = "view_inspay";


            //
            // Exec sql script to insert data
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.view_inspay(pol_id, pol_parent_id, pol_tran_id, pol_transaction_type, pol_policy_number, pol_date_from, pol_date_effective, pol_date_to, pol_date_due, pol_debtor, pay_insurer_id, pol_sub_agent, pol_total_gross_premium, pol_total_net_premium, pay_gross_premium, pay_commission, pay_net_premium, pay_debtor_bal, pay_debtor_adj, pay_insurer_bal, pay_insurer_adj, pay_payable, spid)" + Environment.NewLine +
                               "SELECT pol_id, pol_parent_id, pol_tran_id, pol_transaction_type, pol_policy_number, pol_date_from, pol_date_effective, pol_date_to, pol_date_due, pol_debtor, pay_insurer_id, pol_sub_agent, pol_total_gross_premium, pol_total_net_premium, pay_gross_premium, pay_commission, pay_net_premium, pay_debtor_bal, pay_debtor_adj, pay_insurer_bal, pay_insurer_adj, pay_payable, spid FROM {SOURCE_DATABASE_NAME}.dbo.view_inspay" + Environment.NewLine;
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