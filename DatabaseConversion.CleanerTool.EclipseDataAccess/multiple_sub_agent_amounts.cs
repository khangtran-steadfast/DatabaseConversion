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
    
    public partial class multiple_sub_agent_amounts
    {
        public int saamt_id { get; set; }
        public int saamt_parent_id { get; set; }
        public string saamt_created_who { get; set; }
        public System.DateTime saamt_created_when { get; set; }
        public string saamt_updated_who { get; set; }
        public Nullable<System.DateTime> saamt_updated_when { get; set; }
        public Nullable<int> saamt_duration { get; set; }
        public Nullable<int> saamt_sub_agent_id { get; set; }
        public Nullable<decimal> saamt_comm_deduct { get; set; }
        public Nullable<decimal> saamt_comm_payable { get; set; }
        public Nullable<decimal> saamt_comm_payable_gst { get; set; }
        public Nullable<decimal> saamt_fee_deduct { get; set; }
        public Nullable<decimal> saamt_fee_payable { get; set; }
        public Nullable<decimal> saamt_fee_payable_gst { get; set; }
        public Nullable<decimal> saamt_total_payable { get; set; }
        public Nullable<decimal> saamt_fee_payable_net_gst { get; set; }
        public Nullable<decimal> saamt_comm_payable_net_gst { get; set; }
        public Nullable<decimal> saamt_comm_deduct_gst { get; set; }
        public Nullable<decimal> saamt_comm_deduct_net_gst { get; set; }
    }
}
