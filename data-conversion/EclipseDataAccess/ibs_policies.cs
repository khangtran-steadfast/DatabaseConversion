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
    
    public partial class ibs_policies
    {
        public ibs_policies()
        {
            this.ibs_policy_text = new HashSet<ibs_policy_text>();
        }
    
        public int ibspol_id { get; set; }
        public int ibspol_parent_id { get; set; }
        public string ibspol_created_who { get; set; }
        public System.DateTime ibspol_created_when { get; set; }
        public string ibspol_updated_who { get; set; }
        public Nullable<System.DateTime> ibspol_updated_when { get; set; }
        public Nullable<int> ibspol_duration { get; set; }
        public string ibspol_key { get; set; }
        public string ibspol_client_code { get; set; }
        public Nullable<System.DateTime> ibspol_from_date { get; set; }
        public Nullable<System.DateTime> ibspol_to_date { get; set; }
        public Nullable<System.DateTime> ibspol_attachment_date { get; set; }
        public string ibspol_policy_number { get; set; }
        public string ibspol_cover_note_number { get; set; }
        public string ibspol_location { get; set; }
        public string ibspol_brief_description { get; set; }
        public Nullable<decimal> ibspol_base_premium { get; set; }
        public Nullable<decimal> ibspol_fire_service_levy { get; set; }
        public Nullable<decimal> ibspol_stamp_duty { get; set; }
        public Nullable<decimal> ibspol_brokers_fee { get; set; }
        public Nullable<decimal> ibspol_amount_received { get; set; }
        public Nullable<decimal> ibspol_gross_premium { get; set; }
        public string ibspol_invoice_number { get; set; }
        public Nullable<System.DateTime> ibspol_invoice_date { get; set; }
        public Nullable<decimal> ibspol_commission { get; set; }
        public Nullable<decimal> ibspol_nett_premium { get; set; }
        public Nullable<decimal> ibspol_paid_to_underwriter { get; set; }
        public Nullable<System.DateTime> ibspol_date_underwriter_paid { get; set; }
        public Nullable<decimal> ibspol_sum_insured { get; set; }
        public string ibspol_age_flag { get; set; }
        public string ibspol_lapse_flag { get; set; }
        public string ibspol_invite_flag { get; set; }
        public Nullable<System.DateTime> ibspol_closed_date { get; set; }
        public string ibspol_sub_agent_code { get; set; }
        public Nullable<decimal> ibspol_sub_agent_commission { get; set; }
        public string ibspol_insured_code { get; set; }
        public string ibspol_insured_name { get; set; }
        public string ibspol_underwriter_code { get; set; }
        public string ibspol_underwriter_name { get; set; }
        public string ibspol_underwriter_address_1 { get; set; }
        public string ibspol_underwriter_address_2 { get; set; }
        public string ibspol_underwriter_address_3 { get; set; }
        public string ibspol_underwriter_postcode { get; set; }
        public string ibspol_class_of_risk { get; set; }
        public string ibspol_policy_status { get; set; }
        public string ibspol_policy_type { get; set; }
        public string ibspol_business_category { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual ICollection<ibs_policy_text> ibs_policy_text { get; set; }
    }
}
