//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOALedgerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class task_documents
    {
        public task_documents()
        {
            this.tasks = new HashSet<tasks>();
            this.tasks_sub_tasks = new HashSet<tasks_sub_tasks>();
        }
    
        public int tasdoc_id { get; set; }
        public string tasdoc_created_who { get; set; }
        public System.DateTime tasdoc_created_when { get; set; }
        public string tasdoc_updated_who { get; set; }
        public Nullable<System.DateTime> tasdoc_updated_when { get; set; }
        public string tasdoc_name { get; set; }
        public string tasdoc_desc { get; set; }
        public bool tasdoc_inactive { get; set; }
        public Nullable<int> tasdoc_branch { get; set; }
        public string tasdoc_group { get; set; }
        public bool tasdoc_exclude_as_template { get; set; }
        public bool tasdoc_exclude_as_body { get; set; }
        public string tasdoc_blob_pointer { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<tasks> tasks { get; set; }
        public virtual ICollection<tasks_sub_tasks> tasks_sub_tasks { get; set; }
    }
}
