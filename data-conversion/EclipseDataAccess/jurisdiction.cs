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
    
    public partial class jurisdiction
    {
        public int jur_id { get; set; }
        public string jur_created_who { get; set; }
        public System.DateTime jur_created_when { get; set; }
        public string jur_updated_who { get; set; }
        public Nullable<System.DateTime> jur_updated_when { get; set; }
        public string jur_name { get; set; }
        public string jur_desc { get; set; }
        public Nullable<int> jur_sort { get; set; }
        public bool jur_inactive { get; set; }
    }
}