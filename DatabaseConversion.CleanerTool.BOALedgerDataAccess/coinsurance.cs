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
    
    public partial class coinsurance
    {
        public int coins_id { get; set; }
        public int coins_parent_id { get; set; }
        public string coins_created_who { get; set; }
        public System.DateTime coins_created_when { get; set; }
        public string coins_updated_who { get; set; }
        public Nullable<System.DateTime> coins_updated_when { get; set; }
        public Nullable<int> coins_duration { get; set; }
        public Nullable<decimal> coins_sum_insured { get; set; }
        public Nullable<decimal> coins_percent_insured { get; set; }
        public Nullable<decimal> coins_base_premium { get; set; }
        public Nullable<decimal> coins_levies { get; set; }
        public Nullable<decimal> coins_duties { get; set; }
        public Nullable<decimal> coins_gross_premium { get; set; }
        public Nullable<decimal> coins_commission { get; set; }
        public Nullable<decimal> coins_net_premium { get; set; }
        public Nullable<int> coins_insurer_id { get; set; }
        public Nullable<decimal> coins_insurer_gst { get; set; }
        public Nullable<decimal> coins_comm_gst { get; set; }
        public Nullable<decimal> coins_comm_net_gst { get; set; }
        public Nullable<decimal> coins_uw_fee_net_gst { get; set; }
        public Nullable<decimal> coins_uw_fee_gst { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual policies policies { get; set; }
        public virtual entities entities { get; set; }
    }
}
