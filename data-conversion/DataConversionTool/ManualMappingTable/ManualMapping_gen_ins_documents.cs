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
    public class ManualMapping_gen_ins_documents : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for gen_ins_documents table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_gen_ins_documents()
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
            EclipseDataAccess.gen_ins_documents record = obj as EclipseDataAccess.gen_ins_documents;

            //
            // Run blob pointer converter if needed
            if (record.geninsdo_object_eclipse != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.POLICY_TASK_TEMPLATE, BlobStoreCategories.POLICY_TASK_TEMPLATE, record.geninsdo_object_eclipse);
                this._temporyFilePath.Add(record.geninsdo_id, fullPath);
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
            BOALedgerDataAccess.gen_ins_documents record = obj as BOALedgerDataAccess.gen_ins_documents;
            if (this._temporyFilePath.ContainsKey(record.geninsdo_id))
            {
                record.geninsdo_blob_pointer = this._temporyFilePath[record.geninsdo_id];
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