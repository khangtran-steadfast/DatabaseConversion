using DataConversion.DatabaseMapper;
using DataConversion.Providers.BlobStore;
using DataConversionTool.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversionTool.ManualMappingTable
{
    public class ManualMapping_client_insurance_portfolio : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for client_insurance_portfolio table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_client_insurance_portfolio()
            : base(false)
        {
            this._temporyFilePath = new Dictionary<int, string>();
        }

        /// <summary>
        /// Run BLOBPointer converter before mapping
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="obj"></param>
        public override void BeforeRunningAutoMapper(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, object obj)
        {
            //
            // Cast type
            EclipseDataAccess.client_insurance_portfolio record = obj as EclipseDataAccess.client_insurance_portfolio;

            //
            // Run blob pointer converter if needed
            if (record.cip_document_object_eclipse != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.CLIENT_INSURANCE_PORTFOLIO, BlobStoreCategories.CLIENT_INSURANCE_PORTFOLIO, record.cip_document_object_eclipse);
                this._temporyFilePath.Add(record.cip_id, fullPath);
            }
        }

        /// <summary>
        /// Set blob pointer before mapping
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="obj"></param>
        public override void BeforeMappingRecord(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, object obj)
        {
            BOALedgerDataAccess.client_insurance_portfolio record = obj as BOALedgerDataAccess.client_insurance_portfolio;
            if (this._temporyFilePath.ContainsKey(record.cip_id))
            {
                record.cip_blob_pointer = this._temporyFilePath[record.cip_id];
            }
        }

        /// <summary>
        /// Rellease memory
        /// </summary>
        public override void Dispose()
        {
            this._temporyFilePath.Clear();
            this._temporyFilePath = null;
        }

        /// <summary>
        /// Store tempory file path when convert from Image type to FileSystem
        /// </summary>
        protected Dictionary<int, string> _temporyFilePath;
    }
}