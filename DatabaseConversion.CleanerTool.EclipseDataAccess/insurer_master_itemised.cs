//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.CleanerTool.EclipseDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class insurer_master_itemised
    {
        public System.DateTime pol_created_when { get; set; }
        public int pol_id { get; set; }
        public Nullable<int> pol_tran_id { get; set; }
        public Nullable<System.DateTime> pol_date_effective { get; set; }
        public Nullable<System.DateTime> pol_date_from { get; set; }
        public Nullable<System.DateTime> pol_date_to { get; set; }
        public string pol_policy_number { get; set; }
        public string pol_insured { get; set; }
        public Nullable<int> genins_class_of_business { get; set; }
        public int gencob_id { get; set; }
        public string gencob_name { get; set; }
        public Nullable<int> coins_id { get; set; }
        public Nullable<decimal> coinspercent { get; set; }
        public Nullable<decimal> base_premium { get; set; }
        public Nullable<decimal> levies { get; set; }
        public Nullable<decimal> commission { get; set; }
        public Nullable<decimal> commission_gst { get; set; }
        public Nullable<decimal> gross_premium { get; set; }
        public Nullable<decimal> net_premium { get; set; }
        public Nullable<decimal> policycharge { get; set; }
        public Nullable<decimal> policychargegst { get; set; }
        public Nullable<decimal> othercharges { get; set; }
        public Nullable<System.DateTime> pol_posted_when { get; set; }
        public Nullable<System.DateTime> pol_billing_when { get; set; }
        public string gentrans_name { get; set; }
        public Nullable<int> insurer_id { get; set; }
        public string insurer_name { get; set; }
        public Nullable<decimal> duties { get; set; }
        public Nullable<decimal> insurer_gst { get; set; }
        public short spid { get; set; }
    }
}
