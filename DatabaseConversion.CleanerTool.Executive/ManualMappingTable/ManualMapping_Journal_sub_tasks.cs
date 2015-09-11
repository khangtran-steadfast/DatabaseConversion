using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Executive.Helpers;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Providers.BlobStore;
namespace DatabaseConversion.CleanerTool.Executive.ManualMappingTable
{
    public class ManualMapping_journal_sub_tasks : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for journal_sub_tasks table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_journal_sub_tasks()
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
            EclipseDataAccess.journal_sub_tasks record = obj as EclipseDataAccess.journal_sub_tasks;

            //
            // Run blob pointer converter if needed
            if (record.jousubta_image != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.POLICY_TASK_DOCUMENT, BlobStoreCategories.POLICY_TASK_DOCUMENT, record.jousubta_image);
                this._temporyFilePath.Add(record.jousubta_id, fullPath);
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
            BOALedgerDataAccess.journal_sub_tasks record = obj as BOALedgerDataAccess.journal_sub_tasks;
            if (this._temporyFilePath.ContainsKey(record.jousubta_id))
            {
                record.jousubta_blob_pointer = this._temporyFilePath[record.jousubta_id];
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