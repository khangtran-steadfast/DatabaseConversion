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
    
    public partial class columns
    {
        public columns()
        {
            this.transaction_set_items = new HashSet<transaction_set_items>();
        }
    
        public int col_id { get; set; }
        public string col_created_who { get; set; }
        public System.DateTime col_created_when { get; set; }
        public string col_updated_who { get; set; }
        public Nullable<System.DateTime> col_updated_when { get; set; }
        public int col_parent_id { get; set; }
        public string col_name { get; set; }
        public string col_desc { get; set; }
        public int col_sort { get; set; }
        public bool col_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual tables tables { get; set; }
        public virtual ICollection<transaction_set_items> transaction_set_items { get; set; }
    }
}
