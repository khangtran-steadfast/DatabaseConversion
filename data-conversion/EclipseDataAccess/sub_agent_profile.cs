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
    
    public partial class sub_agent_profile
    {
        public int sap_id { get; set; }
        public int sap_parent_id { get; set; }
        public string sap_created_who { get; set; }
        public System.DateTime sap_created_when { get; set; }
        public string sap_updated_who { get; set; }
        public Nullable<System.DateTime> sap_updated_when { get; set; }
        public Nullable<int> sap_duration { get; set; }
        public Nullable<decimal> sap_new_bus_commission { get; set; }
        public Nullable<decimal> sap_renewal_commission { get; set; }
        public Nullable<decimal> sap_new_business_fee { get; set; }
        public Nullable<decimal> sap_renewal_fee { get; set; }
        public Nullable<decimal> sap_adjustment_commission { get; set; }
        public Nullable<decimal> sap_adjustment_fee { get; set; }
        public bool sap_auto_payment { get; set; }
        public bool sap_exclude_man_payment { get; set; }
        public Nullable<short> sap_comm_calculated_on_base { get; set; }
        public string sap_user { get; set; }
        public Nullable<decimal> sap_nfb_commission { get; set; }
        public int sap_branch { get; set; }
        public string sap_logo { get; set; }
        public string sap_remittance_email_address { get; set; }
    
        public virtual entities entities { get; set; }
    }
}
