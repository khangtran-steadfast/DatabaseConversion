using System;
using System.Collections.Generic;
using System.Linq;
using DataConversion.DatabaseMapper;
using System.Data.Entity;
using DataConversion;
namespace DataConversionTool.ManualMappingTable
{
    /// <summary>
    /// Manual mapping function for workbooks table
    /// This class will NOT override all mapping process
    /// Just override some neccessary processes
    /// </summary>
    public class ManualMapping_workbooks : ManualMapping
    {
        /// <summary>
        /// Create manual mapping for workbooks table
        /// </summary>
        public ManualMapping_workbooks()
            : base(false)
        {
        }


        /// <summary>
        /// After mapping workbooks table completed, we will try to update reference of general_insurance table
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="dataConversionReflection"></param>
        public override void AfterMapping(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            //
            // First, try to get share data
            Dictionary<int, int?> shareData = ManualMappingDropBox.GetData("general_insurance") as Dictionary<int, int?>;
            if(shareData == null)
            {
                LogService.Log.Error("Can not get share data from general_insurance table.");
                return;
            }

            
            //
            // Then try to load new record in general_insurance table (In destination database)
            // To re-update reference
            if (manager.IsGeneratedScript)
            {
                this.UpdateGeneralInsuranceBySQLScript(manager, sourceDatabase, destinationDatabase, shareData);
            }
            else
            {
                BOALedgerDataAccess.BOALedgerEntities dbContext = destinationDatabase.GetNewDbContext() as BOALedgerDataAccess.BOALedgerEntities;
                List<BOALedgerDataAccess.general_insurance> listRecords = dbContext.general_insurance.ToList();
                foreach (BOALedgerDataAccess.general_insurance record in listRecords)
                {
                    if (shareData.ContainsKey(record.genins_id))
                    {
                        record.genins_current_workbook = shareData[record.genins_id];
                    }
                }
                dbContext.SaveChanges();
            }
            


            //
            // Release memory
            shareData = null;
            ManualMappingDropBox.ReleaseData("general_insurance");
        }
                
        /// <summary>
        /// Update general insurance by generate sql script
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="referenceData">Reference data, store reference value from general_insurance -> workbook</param>
        private void UpdateGeneralInsuranceBySQLScript(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, Dictionary<int, int?> referenceData)
        {
            //
            // Initialize
            string destinationDatabaseName = destinationDatabase.GetDatabaseName();
            string sqlScript = "-- This script updates general_insurance table when all records of workbooks table are mapped." + Environment.NewLine +
                               "USE [" + destinationDatabaseName + "]" + Environment.NewLine +
                               "GO" + Environment.NewLine;
            string updateTemplate = "UPDATE {DESTINATION_DATABASE_NAME}.dbo." + Environment.NewLine +
                                    "SET genins_current_workbook = {REFERENCE_VALUE}" + Environment.NewLine +
                                    "WHERE genins_id = {PRIMARY_KEY_VALUE}" + Environment.NewLine;
            updateTemplate.Replace("{DESTINATION_DATABASE_NAME}", destinationDatabaseName);


            //
            // Generate update script
            foreach (int primaryKey in referenceData.Keys)
            {
                sqlScript = sqlScript + updateTemplate.Replace("{PRIMARY_KEY_VALUE}", primaryKey.ToString())
                                                      .Replace("{REFERENCE_VALUE}", referenceData[primaryKey].Value.ToString());
            }


            //
            // Append to workbook script
            manager.WriteSQLScript("workbooks", sqlScript, true);
        }
    }
}
