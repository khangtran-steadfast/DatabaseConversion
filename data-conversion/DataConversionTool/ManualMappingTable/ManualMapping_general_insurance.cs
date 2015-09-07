using DataConversion.DatabaseMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversionTool.ManualMappingTable
{
    /// <summary>
    /// Manual mapping function for general_insurance table
    /// This class will NOT override all mapping process
    /// Just override some neccessary processes
    /// </summary>
    public class ManualMapping_general_insurance : ManualMapping
    {
        /// <summary>
        /// Create new manual mapping function for general_insurance table
        /// </summary>
        public ManualMapping_general_insurance()
            : base(false)
        {

        }

        /// <summary>
        /// Do some stuffs before commit new value to destination database
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="listNewRecord"></param>
        public override void BeforeCommitChanges(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, List<object> listNewRecord)
        {
            //
            // Initialize for sharing data
            Dictionary<int, int?> shareData = new Dictionary<int, int?>();


            //
            // Loop and set null
            foreach (object obj in listNewRecord)
            {
                BOALedgerDataAccess.general_insurance record = obj as BOALedgerDataAccess.general_insurance;
                if (record.genins_current_workbook != null)
                {
                    shareData.Add(record.genins_id, record.genins_current_workbook);
                    record.genins_current_workbook = null;
                }
            }


            //
            // Share data for ManualMapping_workbooks
            ManualMappingDropBox.ShareData("general_insurance", shareData);
        }
    }
}