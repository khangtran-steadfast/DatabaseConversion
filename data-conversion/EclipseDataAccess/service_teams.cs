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
    
    public partial class service_teams
    {
        public service_teams()
        {
            this.administration = new HashSet<administration>();
            this.profile = new HashSet<profile>();
            this.WorkbookMappings_Client = new HashSet<WorkbookMappings_Client>();
        }
    
        public int sertea_id { get; set; }
        public string sertea_created_who { get; set; }
        public System.DateTime sertea_created_when { get; set; }
        public string sertea_updated_who { get; set; }
        public Nullable<System.DateTime> sertea_updated_when { get; set; }
        public string sertea_name { get; set; }
        public string sertea_desc { get; set; }
        public int sertea_sort { get; set; }
        public bool sertea_inactive { get; set; }
        public string sertea_full_name { get; set; }
        public string sertea_branch_id { get; set; }
        public string sertea_title { get; set; }
        public string sertea_address { get; set; }
        public string sertea_suburb { get; set; }
        public Nullable<int> sertea_state { get; set; }
        public string sertea_postcode { get; set; }
        public string sertea_phone { get; set; }
        public string sertea_mobile { get; set; }
        public string sertea_email { get; set; }
    
        public virtual ICollection<administration> administration { get; set; }
        public virtual ICollection<profile> profile { get; set; }
        public virtual ICollection<WorkbookMappings_Client> WorkbookMappings_Client { get; set; }
        public virtual states states { get; set; }
    }
}
