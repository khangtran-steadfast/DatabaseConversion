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
    
    public partial class industry_types
    {
        public industry_types()
        {
            this.profile = new HashSet<profile>();
        }
    
        public int indtyp_id { get; set; }
        public string indtyp_created_who { get; set; }
        public System.DateTime indtyp_created_when { get; set; }
        public string indtyp_updated_who { get; set; }
        public Nullable<System.DateTime> indtyp_updated_when { get; set; }
        public string indtyp_name { get; set; }
        public string indtyp_desc { get; set; }
        public int indtyp_sort { get; set; }
        public bool indtyp_inactive { get; set; }
    
        public virtual ICollection<profile> profile { get; set; }
    }
}
