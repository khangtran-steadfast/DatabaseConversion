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
    
    public partial class policies
    {
        public policies()
        {
            this.brokerlink_policies = new HashSet<brokerlink_policies>();
            this.brokerlink_renewal_takeup = new HashSet<brokerlink_renewal_takeup>();
            this.claims = new HashSet<claims>();
            this.coinsurance = new HashSet<coinsurance>();
            this.sub_agent_amounts = new HashSet<sub_agent_amounts>();
            this.sunrise_policies = new HashSet<sunrise_policies>();
        }
    
        public int pol_id { get; set; }
        public int pol_parent_id { get; set; }
        public string pol_created_who { get; set; }
        public System.DateTime pol_created_when { get; set; }
        public string pol_updated_who { get; set; }
        public Nullable<System.DateTime> pol_updated_when { get; set; }
        public Nullable<int> pol_duration { get; set; }
        public bool pol_closed { get; set; }
        public Nullable<int> pol_insurer { get; set; }
        public Nullable<System.DateTime> pol_date_from { get; set; }
        public Nullable<System.DateTime> pol_date_to { get; set; }
        public Nullable<System.DateTime> pol_date_effective { get; set; }
        public string pol_cover_note_number { get; set; }
        public string pol_policy_number { get; set; }
        public Nullable<decimal> pol_sum_insured { get; set; }
        public Nullable<int> pol_sub_agent { get; set; }
        public string pol_location { get; set; }
        public Nullable<decimal> pol_total_base_premium { get; set; }
        public Nullable<decimal> pol_total_levies { get; set; }
        public Nullable<decimal> pol_total_duties { get; set; }
        public Nullable<decimal> pol_total_fees { get; set; }
        public Nullable<decimal> pol_total_gross_premium { get; set; }
        public Nullable<decimal> pol_total_commission { get; set; }
        public Nullable<decimal> pol_sub_agent_commission { get; set; }
        public string pol_other_parties { get; set; }
        public string pol_particulars { get; set; }
        public string pol_insured { get; set; }
        public Nullable<decimal> pol_total_net_premium { get; set; }
        public Nullable<int> pol_tritm_id { get; set; }
        public Nullable<int> pol_wor_id { get; set; }
        public Nullable<byte> pol_locked { get; set; }
        public Nullable<System.DateTime> pol_posted_when { get; set; }
        public Nullable<System.DateTime> pol_billing_when { get; set; }
        public Nullable<System.DateTime> pol_closing_when { get; set; }
        public Nullable<int> pol_transaction_type { get; set; }
        public Nullable<int> pol_tran_id { get; set; }
        public Nullable<System.DateTime> pol_insurer_sent { get; set; }
        public Nullable<System.DateTime> pol_insurer_received { get; set; }
        public Nullable<decimal> pol_sub_agent_comm_payable { get; set; }
        public Nullable<int> pol_debtor { get; set; }
        public Nullable<decimal> pol_insurer_gst { get; set; }
        public Nullable<System.DateTime> pol_date_due { get; set; }
        public Nullable<decimal> pol_sub_agent_fee { get; set; }
        public Nullable<decimal> pol_sub_agent_fee_payable { get; set; }
        public Nullable<decimal> pol_sub_agent_total_payable { get; set; }
        public Nullable<System.DateTime> pol_date_remitted { get; set; }
        public Nullable<decimal> pol_amount_remitted { get; set; }
        public Nullable<System.DateTime> pol_date_remitted_sub { get; set; }
        public Nullable<decimal> pol_amount_remitted_sub { get; set; }
        public Nullable<decimal> pol_fee_gst { get; set; }
        public Nullable<decimal> pol_comm_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_fee_payable_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_comm_payable_gst { get; set; }
        public Nullable<decimal> pol_total_gst { get; set; }
        public Nullable<decimal> pol_fee_net_gst { get; set; }
        public Nullable<decimal> pol_comm_net_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_fee_pay_net_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_comm_pay_net_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_comm_deduct_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_comm_ded_net_gst { get; set; }
        public Nullable<decimal> pol_invoice_total { get; set; }
        public Nullable<decimal> pol_temp_history_check { get; set; }
        public Nullable<decimal> pol_base_premium { get; set; }
        public Nullable<decimal> pol_uw_fee_gst { get; set; }
        public Nullable<decimal> pol_uw_fee_net_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_fee_deduct_gst { get; set; }
        public Nullable<decimal> pol_sub_agent_fee_net_deduct { get; set; }
        public string pol_reversed { get; set; }
        public Nullable<bool> pol_br_net_com_writeoff { get; set; }
        public Nullable<int> pol_net_br_adjustment { get; set; }
        public Nullable<long> pol_hvi_value { get; set; }
        public Nullable<int> pol_limited_exemption { get; set; }
        public Nullable<int> pol_exemption_type { get; set; }
        public string pol_posted_who { get; set; }
        public Nullable<decimal> pol_balance { get; set; }
        public byte[] RowVersion { get; set; }
        public Nullable<decimal> pol_terrorism_levy { get; set; }
        public string pol_invoice_comments { get; set; }
        public string pol_holding_insurer { get; set; }
        public string pol_interested_parties { get; set; }
        public string pol_closing_comments { get; set; }
        public string pol_schedule_blob_pointer { get; set; }
        public string pol_scope_of_advice { get; set; }
        public string pol_recommendations { get; set; }
        public string pol_notice1 { get; set; }
        public string pol_notice2 { get; set; }
        public string pol_notice3 { get; set; }
        public Nullable<bool> pol_funding_notice_sent { get; set; }
        public Nullable<bool> pol_binder_notice_sent { get; set; }
        public Nullable<System.DateTime> pol_date_fsg_supplied { get; set; }
        public Nullable<bool> pol_auth_rep_notice_sent { get; set; }
        public Nullable<bool> pol_pds_supplied { get; set; }
        public string pol_fsg_version_supplied { get; set; }
        public Nullable<bool> pol_coinsurance { get; set; }
        public Nullable<int> pol_cancellation_reason { get; set; }
        public string pol_cancellation_notes { get; set; }
        public Nullable<int> pol_cancellation_type { get; set; }
        public Nullable<int> pol_step { get; set; }
    
        public virtual ICollection<brokerlink_policies> brokerlink_policies { get; set; }
        public virtual ICollection<brokerlink_renewal_takeup> brokerlink_renewal_takeup { get; set; }
        public virtual ICollection<claims> claims { get; set; }
        public virtual ICollection<coinsurance> coinsurance { get; set; }
        public virtual entities entities { get; set; }
        public virtual entities entities1 { get; set; }
        public virtual entities entities2 { get; set; }
        public virtual exemption_types exemption_types { get; set; }
        public virtual fund_policies2 fund_policies2 { get; set; }
        public virtual gen_ins_transaction_types gen_ins_transaction_types { get; set; }
        public virtual general_insurance general_insurance { get; set; }
        public virtual limited_exemptions limited_exemptions { get; set; }
        public virtual ICollection<sub_agent_amounts> sub_agent_amounts { get; set; }
        public virtual workbooks workbooks { get; set; }
        public virtual ICollection<sunrise_policies> sunrise_policies { get; set; }
        public virtual transactions transactions { get; set; }
    }
}
