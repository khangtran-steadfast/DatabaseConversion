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
    
    public partial class TT_Postcode
    {
        public TT_Postcode()
        {
            this.TT_RiskSection = new HashSet<TT_RiskSection>();
        }
    
        public int ttpc_id { get; set; }
        public string ttpc_created_who { get; set; }
        public System.DateTime ttpc_created_when { get; set; }
        public string ttpc_updated_who { get; set; }
        public Nullable<System.DateTime> ttpc_updated_when { get; set; }
        public string ttpc_suburb { get; set; }
        public string ttpc_postcode { get; set; }
        public int ttpc_state { get; set; }
        public int ttpc_state_code { get; set; }
        public string ttpc_fsl_area { get; set; }
        public string ttpc_terrorism_tier { get; set; }
        public Nullable<int> ttpc_sort { get; set; }
        public bool ttpc_inactive { get; set; }
    
        public virtual states states { get; set; }
        public virtual states states1 { get; set; }
        public virtual ICollection<TT_RiskSection> TT_RiskSection { get; set; }
    }
}
