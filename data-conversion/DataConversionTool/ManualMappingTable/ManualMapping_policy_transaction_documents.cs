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
    public class ManualMapping_policy_transaction_documents : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for policy_transaction_documents table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_policy_transaction_documents()
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
            EclipseDataAccess.policy_transaction_documents record = obj as EclipseDataAccess.policy_transaction_documents;

            //
            // Run blob pointer converter if needed
            if (record.poltrado_object_eclipse != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.POLICY_TRANSACTION_DOCUMENTS, BlobStoreCategories.POLICY_TRANSACTION_DOCUMENTS, record.poltrado_object_eclipse);
                this._temporyFilePath.Add(record.poltrado_id, fullPath);
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
            BOALedgerDataAccess.policy_transaction_documents record = obj as BOALedgerDataAccess.policy_transaction_documents;
            if (this._temporyFilePath.ContainsKey(record.poltrado_id))
            {
                record.poltrado_blob_pointer = this._temporyFilePath[record.poltrado_id];
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