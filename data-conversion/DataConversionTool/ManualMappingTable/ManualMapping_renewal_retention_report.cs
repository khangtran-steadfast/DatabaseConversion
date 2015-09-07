using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;
namespace DataConversionTool.ManualMappingTable
{
    class ManualMapping_renewal_retention_report : ManualMapping
    {
        /// <summary>
        /// Create manual mapping for table renewal_retention_report
        /// This class will take care all mapping process
        /// </summary>
        public ManualMapping_renewal_retention_report()
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
            string tableName = "renewal_retention_report";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.renewal_retention_report(PolID, TranID, Client, SalesTeam, ServiceTeam, Branch, COB, InsurerName, BrokerName, TransactionType, Paid, PartPaid, UnPaid, Lapsed, UnInvited, saltea_id, sertea_id, gencob_id, ent_id, pol_insurer, br_id, tratyp_id, bra_name, genins_id, genins_name, Rentention, Spid, Premium, Earnings, DueDate)" + Environment.NewLine +
                               "SELECT PolID, TranID, Client, SalesTeam, ServiceTeam, Branch, COB, InsurerName, BrokerName, TransactionType, Paid, PartPaid, UnPaid, Lapsed, UnInvited, saltea_id, sertea_id, gencob_id, ent_id, pol_insurer, br_id, tratyp_id, bra_name, genins_id, genins_name, Rentention, Spid, Premium, Earnings, DueDate FROM {SOURCE_DATABASE_NAME}.dbo.renewal_retention_report" + Environment.NewLine;
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
