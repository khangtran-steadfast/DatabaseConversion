using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Providers.BlobStore;
using DatabaseConversion.CleanerTool.Executive.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_notes : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for notes table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_notes()
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
            DatabaseConversion.CleanerTool.EclipseDataAccess.notes record = obj as DatabaseConversion.CleanerTool.EclipseDataAccess.notes;

            //
            // Run blob pointer converter if needed
            if (record.not_object != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.NOTE, BlobStoreCategories.NOTE, record.not_object);
                this._temporyFilePath.Add(record.not_id, fullPath);
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
            DatabaseConversion.CleanerTool.BOALedgerDataAccess.notes record = obj as DatabaseConversion.CleanerTool.BOALedgerDataAccess.notes;
            if (this._temporyFilePath.ContainsKey(record.not_id))
            {
                record.not_blob_pointer = this._temporyFilePath[record.not_id];
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