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
    
    public partial class categories
    {
        public int cat_id { get; set; }
        public int cat_parent_id { get; set; }
        public string cat_created_who { get; set; }
        public System.DateTime cat_created_when { get; set; }
        public string cat_updated_who { get; set; }
        public Nullable<System.DateTime> cat_updated_when { get; set; }
        public Nullable<int> cat_duration { get; set; }
        public Nullable<int> cat_type { get; set; }
        public bool cat_applicable { get; set; }
        public string cat_notes { get; set; }
    
        public virtual personnel personnel { get; set; }
        public virtual category_types category_types { get; set; }
    }
}
