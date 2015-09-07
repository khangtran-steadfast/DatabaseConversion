using System;
using System.Data.Entity;
using System.Linq;
using DataConversion.DatabaseMapper;
using DataConversion;
namespace DataConversionTool.ManualMappingTable
{
    public class ManualMapping_view_DofiReport_Table2 : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for view_DofiReport_Table2 table
        /// This class will take care of all mapping process
        /// </summary>
        public ManualMapping_view_DofiReport_Table2()
            : base(true)
        {

        }

        /// <summary>
        /// Manual mapping function for view_DofiReport_Table2
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
            string tableName = "view_DofiReport_Table2";


            //
            // Generate SQL script
            string sqlQuery = @"INSERT INTO {DESTINATION_DATABASE_NAME}.dbo.view_DofiReport_Table2(spid, gentrans_name, genins_parent_id, pol_tran_id, pol_posted_when, pol_date_effective, apracob_name, merged_base_premium, ent_name, limex_name, uficoco_code, extyp_name, merged_insurer_id, hvi_value)" + Environment.NewLine +
                               "SELECT spid, gentrans_name, genins_parent_id, pol_tran_id, pol_posted_when, pol_date_effective, apracob_name, merged_base_premium, ent_name, limex_name, uficoco_code, extyp_name, merged_insurer_id, hvi_value FROM {SOURCE_DATABASE_NAME}.dbo.view_DofiReport_Table2" + Environment.NewLine;
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