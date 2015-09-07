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
    
    public partial class period_renewals
    {
        public int genins_id { get; set; }
        public string client_name { get; set; }
        public string gencob_name { get; set; }
        public string insurer_name { get; set; }
        public string genins_policy_number { get; set; }
        public string sertea_name { get; set; }
        public string saltea_name { get; set; }
        public string br_name { get; set; }
        public Nullable<System.DateTime> genins_dtfrom { get; set; }
        public Nullable<System.DateTime> genins_dtto { get; set; }
        public Nullable<decimal> invoice_total { get; set; }
        public short spid { get; set; }
        public int entity_id { get; set; }
        public Nullable<int> gencob_id { get; set; }
        public Nullable<int> insurer_id { get; set; }
        public Nullable<int> sertea_id { get; set; }
        public Nullable<int> saltea_id { get; set; }
        public Nullable<int> br_id { get; set; }
        public Nullable<int> bra_id { get; set; }
        public string bra_name { get; set; }
        public Nullable<int> are_id { get; set; }
        public string are_name { get; set; }
        public string genins_name { get; set; }
        public Nullable<decimal> base_premium { get; set; }
        public Nullable<decimal> total_levies { get; set; }
        public Nullable<decimal> insurer_gst { get; set; }
        public Nullable<decimal> total_duties { get; set; }
        public Nullable<decimal> uw_fee_net_gst { get; set; }
        public Nullable<decimal> uw_fee_gst { get; set; }
        public Nullable<decimal> fee_net_gst { get; set; }
        public Nullable<decimal> fee_gst { get; set; }
        public Nullable<decimal> comm_net_gst { get; set; }
        public Nullable<decimal> comm_gst { get; set; }
        public Nullable<decimal> total_net_premium { get; set; }
        public Nullable<int> close_status { get; set; }
    }
}
