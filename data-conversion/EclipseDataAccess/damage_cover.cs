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
    
    public partial class damage_cover
    {
        public int damcov_id { get; set; }
        public string damcov_created_who { get; set; }
        public System.DateTime damcov_created_when { get; set; }
        public string damcov_updated_who { get; set; }
        public Nullable<System.DateTime> damcov_updated_when { get; set; }
        public string damcov_name { get; set; }
        public string damcov_desc { get; set; }
        public Nullable<int> damcov_sort { get; set; }
        public bool damcov_inactive { get; set; }
    }
}
