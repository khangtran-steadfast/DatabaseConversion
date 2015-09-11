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
    public class ManualMapping_confirmation_of_cover : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for confirmation_of_cover table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_confirmation_of_cover()
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
            DatabaseConversion.CleanerTool.EclipseDataAccess.confirmation_of_cover record = obj as DatabaseConversion.CleanerTool.EclipseDataAccess.confirmation_of_cover;

            //
            // Run blob pointer converter if needed
            if (record.coc_document_object_eclipse != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.CONFIRMATION_OF_COVER, BlobStoreCategories.CONFIRMATION_OF_COVER, record.coc_document_object_eclipse);
                this._temporyFilePath.Add(record.coc_id, fullPath);
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
            DatabaseConversion.CleanerTool.BOALedgerDataAccess.confirmation_of_cover record = obj as DatabaseConversion.CleanerTool.BOALedgerDataAccess.confirmation_of_cover;
            if (this._temporyFilePath.ContainsKey(record.coc_id))
            {
                record.coc_blob_pointer = this._temporyFilePath[record.coc_id];
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