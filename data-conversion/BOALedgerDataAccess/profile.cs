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
    
    public partial class profile
    {
        public int prof_id { get; set; }
        public int prof_parent_id { get; set; }
        public string prof_created_who { get; set; }
        public System.DateTime prof_created_when { get; set; }
        public string prof_updated_who { get; set; }
        public Nullable<System.DateTime> prof_updated_when { get; set; }
        public Nullable<int> prof_duration { get; set; }
        public string prof_acn { get; set; }
        public string prof_year_established { get; set; }
        public Nullable<int> prof_structure { get; set; }
        public Nullable<int> prof_area { get; set; }
        public string prof_nature_of_business { get; set; }
        public Nullable<int> prof_industry { get; set; }
        public Nullable<decimal> prof_annual_turnover { get; set; }
        public Nullable<int> prof_number_of_employees { get; set; }
        public Nullable<int> prof_occupation { get; set; }
        public string prof_employer { get; set; }
        public string prof_year_commenced { get; set; }
        public string prof_spouses_name { get; set; }
        public Nullable<int> prof_dependants { get; set; }
        public Nullable<int> prof_service_team { get; set; }
        public Nullable<int> prof_sales_team { get; set; }
        public Nullable<int> prof_source_of_business { get; set; }
        public Nullable<int> prof_usual_debtor { get; set; }
        public Nullable<int> prof_sub_agent { get; set; }
        public Nullable<int> prof_branch { get; set; }
        public Nullable<int> prof_account_type { get; set; }
        public Nullable<int> prof_classification { get; set; }
        public Nullable<int> prof_sub_agent_2 { get; set; }
        public Nullable<int> prof_sub_agent_3 { get; set; }
        public Nullable<int> prof_sub_agent_4 { get; set; }
        public Nullable<int> prof_sub_agent_5 { get; set; }
        public Nullable<int> prof_anzsic { get; set; }
        public Nullable<int> prof_referrer { get; set; }
        public Nullable<int> prof_status { get; set; }
        public string prof_spouses_DOB { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual areas areas { get; set; }
        public virtual branches branches { get; set; }
        public virtual client_account_types client_account_types { get; set; }
        public virtual client_classifications client_classifications { get; set; }
        public virtual entities entities { get; set; }
        public virtual entities entities1 { get; set; }
        public virtual industry_types industry_types { get; set; }
        public virtual occupation_types occupation_types { get; set; }
        public virtual organisation_structures organisation_structures { get; set; }
        public virtual organisation_structures organisation_structures1 { get; set; }
        public virtual service_teams service_teams { get; set; }
        public virtual sales_teams sales_teams { get; set; }
        public virtual sources_of_business sources_of_business { get; set; }
        public virtual profile_referrer profile_referrer { get; set; }
        public virtual profile_status profile_status { get; set; }
    }
}
