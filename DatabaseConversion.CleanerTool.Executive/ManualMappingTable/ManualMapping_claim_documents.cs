using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Providers.BlobStore;
using DatabaseConversion.CleanerTool.Executive.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_claim_documents : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for claim_documents table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_claim_documents()
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
            DatabaseConversion.CleanerTool.EclipseDataAccess.claim_documents record = obj as DatabaseConversion.CleanerTool.EclipseDataAccess.claim_documents;

            //
            // Run blob pointer converter if needed
            if (record.cladoc_object_eclipse != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.CLAIM_TASK_TEMPLATE, BlobStoreCategories.CLAIM_TASK_TEMPLATE, record.cladoc_object_eclipse);
                this._temporyFilePath.Add(record.cladoc_id, fullPath);
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
            DatabaseConversion.CleanerTool.BOALedgerDataAccess.claim_documents record = obj as DatabaseConversion.CleanerTool.BOALedgerDataAccess.claim_documents;
            if (this._temporyFilePath.ContainsKey(record.cladoc_id))
            {
                record.cladoc_blob_pointer = this._temporyFilePath[record.cladoc_id];
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