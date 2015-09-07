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
    public class ManualMapping_tasks_sub_tasks : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for tasks_sub_tasks table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_tasks_sub_tasks()
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
            EclipseDataAccess.tasks_sub_tasks record = obj as EclipseDataAccess.tasks_sub_tasks;

            //
            // Run blob pointer converter if needed
            if (record.tassubta_image != null && !IgnoreBlobs)
            {
                string fullPath = BlobConverter.ConvertToFile(BlobStoreCategories.CLIENT_TASK_DOCUMENT, BlobStoreCategories.CLIENT_TASK_DOCUMENT, record.tassubta_image);
                this._temporyFilePath.Add(record.tassubta_id, fullPath);
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
            BOALedgerDataAccess.tasks_sub_tasks record = obj as BOALedgerDataAccess.tasks_sub_tasks;
            if (this._temporyFilePath.ContainsKey(record.tassubta_id))
            {
                record.tassubta_blob_pointer = this._temporyFilePath[record.tassubta_id];
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