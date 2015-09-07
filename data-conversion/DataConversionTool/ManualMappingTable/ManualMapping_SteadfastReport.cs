using DataConversion.DatabaseMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversionTool.ManualMappingTable
{
    class ManualMapping_SteadfastReport : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for SteadfastReport table
        /// This class will override all auto mapping process
        /// Because we do NOT need SteadfastReport table, so just leave it empty
        /// </summary>
        public ManualMapping_SteadfastReport()
            : base(true)
        {
        }

        /// <summary>
        /// Manual mapping function for SteadfastReport table
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
                manager.WriteSQLScript("SteadfastReport", "", false);
            }
        }
    }
}
