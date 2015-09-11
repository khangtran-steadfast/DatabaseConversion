using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Data.Entity;
using System.Linq;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_ageing_debtors_v : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for ageing_debtors_v table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_ageing_debtors_v()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for ageing_debtors_v
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
            string tableName = "ageing_debtors_v";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.ageing_debtors_v(bal_entity_id, genins_id, genins_name, genins_class_of_business, gencob_name, bal_tran_id, gentrans_name, pol_insurer, insurer_name, pol_policy_number, tran_type, tran_time, pol_date_effective, gross, balamount, days_between, ent_name, Saltea_ID, saltea_name, Sertea_ID, sertea_name, sa_id, sa_name, last_payment, RCPT_AMOUNT, SPID, debtor_fund_status, BRComm)" + Environment.NewLine +
                               "SELECT bal_entity_id, genins_id, genins_name, genins_class_of_business, gencob_name, bal_tran_id, gentrans_name, pol_insurer, insurer_name, pol_policy_number, tran_type, tran_time, pol_date_effective, gross, balamount, days_between, ent_name, Saltea_ID, saltea_name, Sertea_ID, sertea_name, sa_id, sa_name, last_payment, RCPT_AMOUNT, SPID, debtor_fund_status, BRComm FROM {SOURCE_DATABASE_NAME}.dbo.ageing_debtors_v" + Environment.NewLine;
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