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
    
    public partial class TT_PremiumType
    {
        public int ttpt_id { get; set; }
        public string ttpt_created_who { get; set; }
        public System.DateTime ttpt_created_when { get; set; }
        public string ttpt_updated_who { get; set; }
        public Nullable<System.DateTime> ttpt_updated_when { get; set; }
        public string ttpt_code { get; set; }
        public string ttpt_description { get; set; }
        public Nullable<int> ttpt_sort { get; set; }
        public bool ttpt_inactive { get; set; }
    }
}
