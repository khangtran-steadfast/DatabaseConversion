using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;
namespace DataConversionTool.ManualMappingTable
{
    class ManualMapping_IBA : ManualMapping
    {
        /// <summary>
        /// Create manual mapping for table IBA
        /// This class will take care all mapping process
        /// </summary>
        public ManualMapping_IBA()
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
            string tableName = "IBA";


            //
            // Exec sql script to insert data
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.IBA(Fromdate, Todate, adp77, adp78, adp79, adp80, adp81, adp82, adp83, adp84, adp85, adp86, adp87A, adp87B, adp87C, adp87, adp88, adp89, adp90, adp91, adp92, adp93, adp94, adp95, adp100, adp101, adp102, adp103, adp104, adp105, TotalSelfDrawings, TotalGSTDrawings, TotalBrokerRepEarnings, Earnings, GSTonEarnings, DrawnToBrokerRep, DrawnToGST, DrawnToSelf, Adjustments, adp106A, adp106b, adp106c, adp106, adp107, adp108, CashClosingBalance, Asic26DiffAmount, Asic27DiffAmount, spid)" + Environment.NewLine +
                               "SELECT Fromdate, Todate, adp77, adp78, adp79, adp80, adp81, adp82, adp83, adp84, adp85, adp86, adp87A, adp87B, adp87C, adp87, adp88, adp89, adp90, adp91, adp92, adp93, adp94, adp95, adp100, adp101, adp102, adp103, adp104, adp105, TotalSelfDrawings, TotalGSTDrawings, TotalBrokerRepEarnings, Earnings, GSTonEarnings, DrawnToBrokerRep, DrawnToGST, DrawnToSelf, Adjustments, adp106A, adp106b, adp106c, adp106, adp107, adp108, CashClosingBalance, Asic26DiffAmount, Asic27DiffAmount, spid FROM {SOURCE_DATABASE_NAME}.dbo.IBA" + Environment.NewLine;
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
