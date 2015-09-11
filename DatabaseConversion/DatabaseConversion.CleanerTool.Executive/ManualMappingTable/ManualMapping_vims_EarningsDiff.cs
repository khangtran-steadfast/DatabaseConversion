using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Data.Entity;
using System.Linq;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_vims_EarningsDiff : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for vims_EarningsDiff table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_vims_EarningsDiff()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for vims_EarningsDiff
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
            string tableName = "vims_EarningsDiff";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.vims_EarningsDiff(Pol_tran_id, BrRep_EarningWithAdj, Paid, Payable, Liability, Adjustment, BrRep_EarningWithoutAdj, pol_insured, gentrans_name, gencob_Name, short_payment_broker_rep_poriton)" + Environment.NewLine +
                               "SELECT Pol_tran_id, BrRep_EarningWithAdj, Paid, Payable, Liability, Adjustment, BrRep_EarningWithoutAdj, pol_insured, gentrans_name, gencob_Name, short_payment_broker_rep_poriton FROM {SOURCE_DATABASE_NAME}.dbo.vims_EarningsDiff" + Environment.NewLine;
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