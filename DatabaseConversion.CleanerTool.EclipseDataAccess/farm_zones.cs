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
    
    public partial class farm_zones
    {
        public int farzon_id { get; set; }
        public string farzon_created_who { get; set; }
        public System.DateTime farzon_created_when { get; set; }
        public string farzon_updated_who { get; set; }
        public Nullable<System.DateTime> farzon_updated_when { get; set; }
        public string farzon_name { get; set; }
        public string farzon_desc { get; set; }
        public Nullable<int> farzon_sort { get; set; }
        public bool farzon_inactive { get; set; }
        public Nullable<double> farzon_loading { get; set; }
    }
}
