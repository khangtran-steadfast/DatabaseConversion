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
    
    public partial class transaction_sets
    {
        public transaction_sets()
        {
            this.transaction_set_items = new HashSet<transaction_set_items>();
        }
    
        public int traset_id { get; set; }
        public string traset_created_who { get; set; }
        public System.DateTime traset_created_when { get; set; }
        public string traset_updated_who { get; set; }
        public Nullable<System.DateTime> traset_updated_when { get; set; }
        public string traset_name { get; set; }
        public string traset_desc { get; set; }
        public bool traset_inactive { get; set; }
        public Nullable<int> traset_type { get; set; }
        public Nullable<int> traset_currency { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual ICollection<transaction_set_items> transaction_set_items { get; set; }
        public virtual transaction_types transaction_types { get; set; }
    }
}
