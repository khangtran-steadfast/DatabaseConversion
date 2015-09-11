using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Data.Entity;
using System.Linq;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    class ManualMapping_statements : ManualMapping
    {
        /// <summary>
        /// Create manual mapping for statements table
        /// This class will take care all mapping process
        /// </summary>
        public ManualMapping_statements()
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
            string tableName = "statements";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.statements(gltr_glsl_id, glsl_entity_id, glsl_name, gltr_id, gltr_date, glmv_date, glmv_id, glmv_glrs_set, glmv_record_ref_id, origamount, gltr_amount, debit, credit, balance, unalloccash, netbalance, pol_id, pol_id1, pol_tran_id, pol_tran_id1, tran_id, Pol_policy_number, genins_name, genins_class_of_business, gencob_name, paymethod, client, sortid, spid, salesteam, BRComm, NetDue, BRClient, StatementInsurer, PaymentType, InvoiceComments)" + Environment.NewLine +
                               "SELECT gltr_glsl_id, glsl_entity_id, glsl_name, gltr_id, gltr_date, glmv_date, glmv_id, glmv_glrs_set, glmv_record_ref_id, origamount, gltr_amount, debit, credit, balance, unalloccash, netbalance, pol_id, pol_id1, pol_tran_id, pol_tran_id1, tran_id, Pol_policy_number, genins_name, genins_class_of_business, gencob_name, paymethod, client, sortid, spid, salesteam, BRComm, NetDue, BRClient, StatementInsurer, PaymentType, InvoiceComments FROM {SOURCE_DATABASE_NAME}.dbo.statements" + Environment.NewLine;
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
