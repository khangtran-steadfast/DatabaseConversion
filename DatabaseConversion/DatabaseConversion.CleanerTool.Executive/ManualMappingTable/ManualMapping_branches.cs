using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Collections;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    /// <summary>
    /// Manual mapping function for branches table
    /// This class will NOT override all mapping process
    /// Just override some neccessary processes
    /// </summary>
    public class ManualMapping_branches : ManualMapping
    {
        /// <summary>
        /// Create new manual mapping for branches table
        /// </summary>
        public ManualMapping_branches()
            : base(false)
        {
            this._listReferenceValue = new Dictionary<int, int?>();
        }

        /// <summary>
        /// Manual function, after mapping completed, we will re-update reference value
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public override void AfterMapping(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            //
            // First, try to load new record in destination database
            string destinationDatabaseName = destinationDatabase.GetDatabaseName();


            //
            // Try to update
            if (manager.IsGeneratedScript)
            {
                //
                // First generate update script
                string sqlScript = "USE [" + destinationDatabaseName + "]" + Environment.NewLine +
                                   "GO" + Environment.NewLine;
                string updateTemplate = "UPDATE {DESTINATION_DATABASE_NAME}.dbo.branches" + Environment.NewLine +
                                        "SET bra_parent_branch = {REFERENCE_VALUE}" + Environment.NewLine +
                                        "WHERE bra_id = {PRIMARY_KEY_VALUE}" + Environment.NewLine;
                updateTemplate = updateTemplate.Replace("{DESTINATION_DATABASE_NAME}", destinationDatabase.GetDatabaseName());
                foreach (int primaryKeyValue in this._listReferenceValue.Keys)
                {
                    int? referenceValue = this._listReferenceValue[primaryKeyValue];
                    sqlScript = sqlScript + updateTemplate.Replace("{REFERENCE_VALUE}", referenceValue.Value.ToString())
                                                          .Replace("{PRIMARY_KEY_VALUE}", primaryKeyValue.ToString());
                }


                //
                // Then append to file (existed file)
                manager.WriteSQLScript("branches", sqlScript, true);
            }
            else
            {
                //
                // If we do not generate sql script
                // we need to update directly in destination table
                BOALedgerDataAccess.BOALedgerEntities dbContext = destinationDatabase.GetDbContext() as BOALedgerDataAccess.BOALedgerEntities;
                List<BOALedgerDataAccess.branches> listRecords = dbContext.branches.ToList();
                foreach (BOALedgerDataAccess.branches record in listRecords)
                {
                    if (this._listReferenceValue.ContainsKey(record.bra_id))
                    {
                        record.bra_parent_branch = this._listReferenceValue[record.bra_id];
                    }
                }
                dbContext.SaveChanges();
            }
        }
        
        /// <summary>
        /// Manual function before mapping record
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="record"></param>
        public override void BeforeMappingRecord(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, object record)
        {
            //
            // Because this table has self reference
            // Column bra_parent_branches references to bra_id column
            // So at first, we need to set bra_parent_branch to null
            // After moving all record from Branches table in source to destination
            // We will try update reference later
            BOALedgerDataAccess.branches branchesRecord = record as BOALedgerDataAccess.branches;
            if (branchesRecord.bra_parent_branch != null)
            {
                this._listReferenceValue.Add(branchesRecord.bra_id, branchesRecord.bra_parent_branch);
                branchesRecord.bra_parent_branch = null;
            }
        }

        /// <summary>
        /// Rellease memory
        /// </summary>
        public override void Dispose()
        {
            this._listReferenceValue.Clear();
        }

        /// <summary>
        /// Tempory list to store old value of column "bra_parent_branch"
        /// For each pair in list, the value is (bra_id, bra_parent_branch)
        /// </summary>
        protected Dictionary<int, int?> _listReferenceValue;
    }
}
