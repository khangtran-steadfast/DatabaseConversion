//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.CleanerTool.BOALedgerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class gen_ins_wor_doc_types
    {
        public gen_ins_wor_doc_types()
        {
            this.policy_transaction_documents = new HashSet<policy_transaction_documents>();
            this.gen_ins_wor_documents = new HashSet<gen_ins_wor_documents>();
            this.journals = new HashSet<journals>();
        }
    
        public int giwdtyp_id { get; set; }
        public string giwdtyp_created_who { get; set; }
        public System.DateTime giwdtyp_created_when { get; set; }
        public string giwdtyp_updated_who { get; set; }
        public Nullable<System.DateTime> giwdtyp_updated_when { get; set; }
        public string giwdtyp_name { get; set; }
        public string giwdtyp_desc { get; set; }
        public bool giwdtyp_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<policy_transaction_documents> policy_transaction_documents { get; set; }
        public virtual ICollection<gen_ins_wor_documents> gen_ins_wor_documents { get; set; }
        public virtual ICollection<journals> journals { get; set; }
    }
}
