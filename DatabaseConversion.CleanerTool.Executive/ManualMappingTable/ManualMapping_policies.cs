using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DocumentGenerator;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_policies : ManualMapping
    {
        /// <summary>
        /// Manual mapping function for policies table
        /// This class will NOT override all mapping process
        /// Just override some neccessary processes
        /// </summary>
        public ManualMapping_policies()
            : base(false)
        {

        }

        /// <summary>
        /// Before add policies record into BOALedger database, we will try to update value from Workbook_SOA Table
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="record"></param>
        public override void BeforeMappingRecord(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, object obj)
        {
            //
            // Cast type
            DatabaseConversion.CleanerTool.BOALedgerDataAccess.policies record = obj as DatabaseConversion.CleanerTool.BOALedgerDataAccess.policies;
            

            //
            // Check does this record reference to workbooks table or not ?
            // If it does, we need to check the value of 
            if (record.pol_wor_id.HasValue)
            {
                DatabaseConversion.CleanerTool.EclipseDataAccess.EclipseDatabaseEntities sourceDbContext = sourceDatabase.GetNewDbContext() as DatabaseConversion.CleanerTool.EclipseDataAccess.EclipseDatabaseEntities;
                

                //
                // Get related workbook_SOA record
                DatabaseConversion.CleanerTool.EclipseDataAccess.Workbook_SOA workbook_SOARecord = 
                    (from workbook_SOATable in sourceDbContext.Workbook_SOA
                    join workbooksTable in sourceDbContext.workbooks on workbook_SOATable.ws_parent_id equals workbooksTable.wor_id
                    where workbooksTable.wor_id == record.pol_wor_id.Value
                    select workbook_SOATable).FirstOrDefault();


                //
                // If not null, try to convert and assign new value to record
                if (workbook_SOARecord != null)
                {
                    if (workbook_SOARecord.ws_scopeofadvice != null)
                    {
                        record.pol_scope_of_advice = WordGenerator.ConvertRtfToHtml(WordGenerator.ConvertDocxToRTF(workbook_SOARecord.ws_scopeofadvice));
                    }
                    if (workbook_SOARecord.ws_recommendations != null)
                    {
                        record.pol_recommendations = WordGenerator.ConvertRtfToHtml(WordGenerator.ConvertDocxToRTF(workbook_SOARecord.ws_recommendations));
                    }
                    if (workbook_SOARecord.ws_notice1 != null)
                    {
                        record.pol_notice1 = WordGenerator.ConvertRtfToHtml(WordGenerator.ConvertDocxToRTF(workbook_SOARecord.ws_notice1));
                    }
                    if (workbook_SOARecord.ws_notice2 != null)
                    {
                        record.pol_notice2 = WordGenerator.ConvertRtfToHtml(WordGenerator.ConvertDocxToRTF(workbook_SOARecord.ws_notice2));
                    }
                    if (workbook_SOARecord.ws_notice3 != null)
                    {
                        record.pol_notice3 = WordGenerator.ConvertRtfToHtml(WordGenerator.ConvertDocxToRTF(workbook_SOARecord.ws_notice3));
                    }
                }
            }
        }
    }
}
