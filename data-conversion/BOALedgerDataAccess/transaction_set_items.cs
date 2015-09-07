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
    
    public partial class transaction_set_items
    {
        public int trasetit_id { get; set; }
        public string trasetit_created_who { get; set; }
        public System.DateTime trasetit_created_when { get; set; }
        public string trasetit_updated_who { get; set; }
        public Nullable<System.DateTime> trasetit_updated_when { get; set; }
        public int trasetit_parent_id { get; set; }
        public string trasetit_name { get; set; }
        public string trasetit_desc { get; set; }
        public bool trasetit_inactive { get; set; }
        public Nullable<int> trasetit_account_type { get; set; }
        public Nullable<int> trasetit_control_account { get; set; }
        public Nullable<byte> trasetit_debit { get; set; }
        public Nullable<int> trasetit_source_table { get; set; }
        public Nullable<int> trasetit_source_column { get; set; }
        public Nullable<int> trasetit_ledger { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual account_types account_types { get; set; }
        public virtual columns columns { get; set; }
        public virtual entities entities { get; set; }
        public virtual gl_ledgers gl_ledgers { get; set; }
        public virtual tables tables { get; set; }
        public virtual transaction_sets transaction_sets { get; set; }
    }
}
