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
    
    public partial class gen_ins_documents
    {
        public gen_ins_documents()
        {
            this.journal_sub_tasks = new HashSet<journal_sub_tasks>();
            this.journals = new HashSet<journals>();
            this.gen_ins_wor_documents = new HashSet<gen_ins_wor_documents>();
        }
    
        public int geninsdo_id { get; set; }
        public string geninsdo_created_who { get; set; }
        public System.DateTime geninsdo_created_when { get; set; }
        public string geninsdo_updated_who { get; set; }
        public Nullable<System.DateTime> geninsdo_updated_when { get; set; }
        public string geninsdo_name { get; set; }
        public string geninsdo_desc { get; set; }
        public bool geninsdo_inactive { get; set; }
        public Nullable<int> geninsdo_branch { get; set; }
        public string geninsdo_group { get; set; }
        public bool geninsdo_exclude_as_template { get; set; }
        public bool geninsdo_exclude_as_body { get; set; }
        public string geninsdo_blob_pointer { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<journal_sub_tasks> journal_sub_tasks { get; set; }
        public virtual ICollection<journals> journals { get; set; }
        public virtual ICollection<gen_ins_wor_documents> gen_ins_wor_documents { get; set; }
    }
}
