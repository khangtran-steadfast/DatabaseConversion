using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    class ManualMapping_Workbook_SOA : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for Workbook_SOA table
        /// This class will override all auto mapping process
        /// Because we do NOT need Workbook_SOA table, so just leave it empty
        /// </summary>
        public ManualMapping_Workbook_SOA()
            : base(true)
        {
        }

        /// <summary>
        /// Manual mapping function for Workbook_SOA table
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public override void Map(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            //
            // Create dump migration script if needed
            if (manager.IsGeneratedScript)
            {
                manager.WriteSQLScript("Workbook_SOA", "", false);
            }
        }
    }
}
