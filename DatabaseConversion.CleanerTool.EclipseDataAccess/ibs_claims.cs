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
    
    public partial class ibs_claims
    {
        public int ibsclm_id { get; set; }
        public int ibsclm_parent_id { get; set; }
        public string ibsclm_created_who { get; set; }
        public System.DateTime ibsclm_created_when { get; set; }
        public string ibsclm_updated_who { get; set; }
        public Nullable<System.DateTime> ibsclm_updated_when { get; set; }
        public Nullable<int> ibsclm_duration { get; set; }
        public string ibsclm_key { get; set; }
        public string ibsclm_claim_number { get; set; }
        public string ibsclm_claim_status { get; set; }
        public string ibsclm_underwriter_reference { get; set; }
        public Nullable<decimal> ibsclm_sum_insured { get; set; }
        public Nullable<decimal> ibsclm_excess { get; set; }
        public Nullable<decimal> ibsclm_estimate { get; set; }
        public Nullable<decimal> ibsclm_amount_paid { get; set; }
        public Nullable<System.DateTime> ibsclm_date_of_loss { get; set; }
        public Nullable<System.DateTime> ibsclm_review_date { get; set; }
        public Nullable<System.DateTime> ibsclm_previous_review_date { get; set; }
        public string ibsclm_policy_key { get; set; }
        public string ibsclm_detail_line_1 { get; set; }
        public string ibsclm_detail_line_2 { get; set; }
        public string ibsclm_detail_line_3 { get; set; }
        public string ibsclm_detail_line_4 { get; set; }
        public string ibsclm_memo_line_1 { get; set; }
        public string ibsclm_memo_line_2 { get; set; }
        public string ibsclm_memo_line_3 { get; set; }
        public string ibsclm_memo_line_4 { get; set; }
        public string ibsclm_action_line_1 { get; set; }
        public string ibsclm_action_line_2 { get; set; }
        public Nullable<System.DateTime> ibsclm_last_action_date { get; set; }
        public string ibsclm_client_code { get; set; }
    
        public virtual entities entities { get; set; }
    }
}
