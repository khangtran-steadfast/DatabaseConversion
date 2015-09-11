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
    public class ManualMapping_general_insurance_workbooks : ManualMapping
    {
        /// <summary>
        /// Create Manual mapping for general_insurance_workbooks table
        /// This class will NOT override all auto mapping process
        /// Just override some methods that we need
        /// </summary>
        public ManualMapping_general_insurance_workbooks()
            : base(false)
        {
            this._documentFilePath = new Dictionary<int, string>();
            this._portfolioFilePath = new Dictionary<int, string>();
            this._cocFilePath = new Dictionary<int, string>();
            this._objectFilePath = new Dictionary<int, string>();
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
            DatabaseConversion.CleanerTool.EclipseDataAccess.general_insurance_workbooks record = obj as DatabaseConversion.CleanerTool.EclipseDataAccess.general_insurance_workbooks;

            //
            // Run blob pointer converter if needed
            if (record.geninswb_document_object_eclipse != null && !IgnoreBlobs)
            {
                string blobPointer = BlobConverter.ConvertToFile(BlobStoreCategories.POLICY_TRANSACTION, BlobStoreCategories.POLICY_TRANSACTION, record.geninswb_document_object_eclipse);
                this._documentFilePath.Add(record.geninswb_id, blobPointer);
            }
            if (record.geninswb_portfolio_object_eclipse != null && !IgnoreBlobs)
            {
                string blobPointer = BlobConverter.ConvertToFile(BlobStoreCategories.POLICY_TRANSACTION, BlobStoreCategories.POLICY_TRANSACTION, record.geninswb_portfolio_object_eclipse);
                this._portfolioFilePath.Add(record.geninswb_id, blobPointer);
            }
            if (record.geninswb_coc_eclipse != null && !IgnoreBlobs)
            {
                string blobPointer = BlobConverter.ConvertToFile(BlobStoreCategories.POLICY_TRANSACTION, BlobStoreCategories.POLICY_TRANSACTION, record.geninswb_coc_eclipse);
                this._cocFilePath.Add(record.geninswb_id, blobPointer);
            }
            if (record.geninswb_object_eclipse != null && !IgnoreBlobs)
            {
                string blobPointer = BlobConverter.ConvertToFile(BlobStoreCategories.POLICY_TRANSACTION, BlobStoreCategories.POLICY_TRANSACTION, record.geninswb_object_eclipse);
                this._objectFilePath.Add(record.geninswb_id, blobPointer);
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
            DatabaseConversion.CleanerTool.BOALedgerDataAccess.general_insurance_workbooks record = obj as DatabaseConversion.CleanerTool.BOALedgerDataAccess.general_insurance_workbooks;
            if (this._documentFilePath.ContainsKey(record.geninswb_id))
            {
                record.geninswb_blob_pointer_document = this._documentFilePath[record.geninswb_id];
            }
            if (this._portfolioFilePath.ContainsKey(record.geninswb_id))
            {
                record.geninswb_blob_pointer_portfolio = this._portfolioFilePath[record.geninswb_id];
            }
            if (this._cocFilePath.ContainsKey(record.geninswb_id))
            {
                record.geninswb_blob_pointer_coc = this._cocFilePath[record.geninswb_id];
            }
            if (this._objectFilePath.ContainsKey(record.geninswb_id))
            {
                record.geninswb_blob_pointer_object = this._objectFilePath[record.geninswb_id];
            }
        }

        /// <summary>
        /// Rellease memory
        /// </summary>
        public override void Dispose()
        {
            this._documentFilePath.Clear();
            this._portfolioFilePath.Clear();
            this._cocFilePath.Clear();
            this._objectFilePath.Clear();
            this._documentFilePath = null;
            this._portfolioFilePath = null;
            this._cocFilePath = null;
            this._objectFilePath = null;
        }

        /// <summary>
        /// Store tempory file path for geninswb_document_object_eclipse
        /// </summary>
        protected Dictionary<int, string> _documentFilePath;
        
        /// <summary>
        /// Store tempory file path for geninswb_portfolio_object_eclipse
        /// </summary>
        protected Dictionary<int, string> _portfolioFilePath;

        /// <summary>
        /// Store tempory file path for geninswb_coc_eclipse
        /// </summary>
        protected Dictionary<int, string> _cocFilePath;

        /// <summary>
        /// Store tempory file path for geninswb_object_eclipse
        /// </summary>
        protected Dictionary<int, string> _objectFilePath;
    }
}