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
    
    public partial class exemption_types
    {
        public exemption_types()
        {
            this.policies = new HashSet<policies>();
        }
    
        public int extyp_id { get; set; }
        public int extyp_parent_id { get; set; }
        public string extyp_created_who { get; set; }
        public System.DateTime extyp_created_when { get; set; }
        public string extyp_updated_who { get; set; }
        public Nullable<System.DateTime> extyp_updated_when { get; set; }
        public string extyp_name { get; set; }
        public string extyp_desc { get; set; }
        public Nullable<int> extyp_sort { get; set; }
        public bool extyp_inactive { get; set; }
    
        public virtual limited_exemptions limited_exemptions { get; set; }
        public virtual ICollection<policies> policies { get; set; }
    }
}
