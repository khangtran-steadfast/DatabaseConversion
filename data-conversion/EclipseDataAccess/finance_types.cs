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
    
    public partial class finance_types
    {
        public int fintyp_id { get; set; }
        public string fintyp_created_who { get; set; }
        public System.DateTime fintyp_created_when { get; set; }
        public string fintyp_updated_who { get; set; }
        public Nullable<System.DateTime> fintyp_updated_when { get; set; }
        public string fintyp_name { get; set; }
        public string fintyp_desc { get; set; }
        public Nullable<int> fintyp_sort { get; set; }
        public bool fintyp_inactive { get; set; }
    }
}
