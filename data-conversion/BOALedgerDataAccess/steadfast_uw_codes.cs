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
    
    public partial class steadfast_uw_codes
    {
        public int suc_id { get; set; }
        public Nullable<int> suc_insurer_id { get; set; }
        public string suc_uw_code { get; set; }
        public string suc_description { get; set; }
        public Nullable<int> suc_sp { get; set; }
        public string suc_created_who { get; set; }
        public System.DateTime suc_created_when { get; set; }
        public string suc_updated_who { get; set; }
        public Nullable<System.DateTime> suc_updated_when { get; set; }
        public int suc_sort { get; set; }
        public bool suc_inactive { get; set; }
    }
}
