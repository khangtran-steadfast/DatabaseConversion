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
    
    public partial class currency
    {
        public currency()
        {
            this.transaction_sets = new HashSet<transaction_sets>();
        }
    
        public int cur_id { get; set; }
        public string cur_created_who { get; set; }
        public System.DateTime cur_created_when { get; set; }
        public string cur_updated_who { get; set; }
        public Nullable<System.DateTime> cur_updated_when { get; set; }
        public string cur_name { get; set; }
        public string cur_desc { get; set; }
        public bool cur_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<transaction_sets> transaction_sets { get; set; }
    }
}
