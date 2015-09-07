using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.Providers.BlobStore
{
    /// <summary>
    /// Codes for Blob Store Categories
    /// </summary>
    /// <remarks>
    /// We keep the codes short because it forms part of the key and we don't want long keys because they cost more to store.
    /// </remarks>
    public static class BlobStoreCategories
    {
        /// <summary>
        /// Blobs in the claim_sub_tasks table
        /// </summary>
        public static readonly string CLAIM_TASK_DOCUMENT = "LTD";

        /// <summary>
        /// Blobs in claim_documents table
        /// </summary>
        public static readonly string CLAIM_TASK_TEMPLATE = "LTT";

        /// <summary>
        /// Blobs in the client_insurance_portfolio table
        /// </summary>
        public static readonly string CLIENT_INSURANCE_PORTFOLIO = "CIP";

        /// <summary>
        /// Blobs in the tasks_sub_tasks table
        /// </summary>
        public static readonly string CLIENT_TASK_DOCUMENT = "CTD";

        /// <summary>
        /// Blobs in the task_documents table
        /// </summary>
        public static readonly string CLIENT_TASK_TEMPLATE = "CTT";

        /// <summary>
        /// Blobs in the confirmation_of_cover table
        /// </summary>
        public static readonly string CONFIRMATION_OF_COVER = "COC";

        /// <summary>
        /// Blobs in the DocumentRepository table
        /// </summary>
        public static readonly string DOCUMENT_REPOSITORY = "DOR";

        /// <summary>
        /// Blobs in the EmailTemplates table
        /// </summary>
        public static readonly string EMAIL_TEMPLATE = "EMT";

        /// <summary>
        /// Blobs in the notes table
        /// </summary>
        public static readonly string NOTE = "NTE";

        /// <summary>
        /// Blobs in the journal_sub_tasks table
        /// </summary>
        public static readonly string POLICY_TASK_DOCUMENT = "PTD";

        /// <summary>
        /// Blobs in the gen_ins_documents table
        /// </summary>
        public static readonly string POLICY_TASK_TEMPLATE = "PTT";

        /// <summary>
        /// Blobs in the general_insurance_workbooks table
        /// </summary>
        public static readonly string POLICY_TRANSACTION = "PTX";

        /// <summary>
        /// Blobs in the policy_transaction_documents table
        /// </summary>
        public static readonly string POLICY_TRANSACTION_DOCUMENTS = "PTD";

        /// <summary>
        /// Temp area to store blobs.  Blobs older than 24 hours will be deleted.
        /// </summary>
        public static readonly string TEMP = "TMP";
    }
}
