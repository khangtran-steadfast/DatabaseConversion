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
    
    public partial class territorial_limits
    {
        public int terlim_id { get; set; }
        public string terlim_created_who { get; set; }
        public System.DateTime terlim_created_when { get; set; }
        public string terlim_updated_who { get; set; }
        public Nullable<System.DateTime> terlim_updated_when { get; set; }
        public string terlim_name { get; set; }
        public string terlim_desc { get; set; }
        public Nullable<int> terlim_sort { get; set; }
        public bool terlim_inactive { get; set; }
    }
}