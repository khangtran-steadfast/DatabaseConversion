//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EclipseDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class draw_earn
    {
        public int pol_id { get; set; }
        public Nullable<int> pol_insurer { get; set; }
        public Nullable<System.DateTime> pol_date_effective { get; set; }
        public string pol_policy_number { get; set; }
        public Nullable<int> pol_transaction_Type { get; set; }
        public Nullable<int> pol_sub_agent { get; set; }
        public Nullable<System.DateTime> pol_posted_when { get; set; }
        public int pol_parent_id { get; set; }
        public Nullable<int> pol_tran_id { get; set; }
        public Nullable<int> pol_debtor { get; set; }
        public Nullable<decimal> pol_invoice_total { get; set; }
        public Nullable<decimal> pol_total_net_premium { get; set; }
        public Nullable<decimal> pol_total_commission { get; set; }
        public Nullable<decimal> pol_total_fees { get; set; }
        public Nullable<decimal> pol_sub_agent_comm_payable { get; set; }
        public Nullable<decimal> pol_sub_agent_fee_payable { get; set; }
        public Nullable<decimal> pol_sub_agent_total_payable { get; set; }
        public Nullable<decimal> pol_broker_net_commission { get; set; }
        public Nullable<decimal> NetBrokerCommGST { get; set; }
        public Nullable<decimal> pol_broker_net_fees { get; set; }
        public Nullable<decimal> NetFeeGst { get; set; }
        public Nullable<decimal> pol_total_broker_earnings { get; set; }
        public Nullable<decimal> debtor_unadjusted_balance { get; set; }
        public Nullable<decimal> debtor_excess_payment { get; set; }
        public Nullable<decimal> debtor_short_payment { get; set; }
        public Nullable<decimal> creditor_adjustments { get; set; }
        public Nullable<decimal> received_amt { get; set; }
        public Nullable<System.DateTime> latest_receipt_date { get; set; }
        public Nullable<decimal> Pol_sub_agent_Comm_pay_net_gst { get; set; }
        public Nullable<decimal> Pol_sub_agent_fee_pay_net_gst { get; set; }
        public Nullable<decimal> Pol_sub_agent_fee_payable_gst { get; set; }
        public Nullable<decimal> total_earnings { get; set; }
        public Nullable<decimal> short_payment_broker_poriton { get; set; }
        public Nullable<decimal> short_payment_broker_rep_poriton { get; set; }
        public Nullable<decimal> broker_earnings { get; set; }
        public Nullable<decimal> broker_rep_earnings { get; set; }
        public Nullable<decimal> earn_broker_comm { get; set; }
        public Nullable<decimal> earn_broker_fee { get; set; }
        public Nullable<decimal> earn_broker_rep_comm { get; set; }
        public Nullable<decimal> earn_broker_rep_fee { get; set; }
        public Nullable<decimal> earn_broker_comm_gst { get; set; }
        public Nullable<decimal> earn_broker_fee_gst { get; set; }
        public Nullable<decimal> earn_broker_rep_comm_gst { get; set; }
        public Nullable<decimal> earn_broker_rep_fee_gst { get; set; }
        public string genins_name { get; set; }
        public Nullable<int> Ent_ID { get; set; }
        public string pol_insured { get; set; }
        public Nullable<int> genins_class_of_business { get; set; }
        public Nullable<decimal> Drawn_Amount { get; set; }
        public Nullable<decimal> NetEarned { get; set; }
        public short SPID { get; set; }
    }
}
