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
    
    public partial class TimProducts
    {
        public int TimPro_id { get; set; }
        public string TimPro_created_who { get; set; }
        public System.DateTime TimPro_created_when { get; set; }
        public string TimPro_updated_who { get; set; }
        public Nullable<System.DateTime> TimPro_updated_when { get; set; }
        public int TimPro_parent_id { get; set; }
        public int TimPro_cob_id { get; set; }
        public string TimPro_name { get; set; }
        public string TimPro_desc { get; set; }
        public Nullable<int> TimPro_sort { get; set; }
        public bool TimPro_inactive { get; set; }
        public string TimPro_product_code { get; set; }
    
        public virtual gen_ins_classes_of_business gen_ins_classes_of_business { get; set; }
        public virtual TimInsurers TimInsurers { get; set; }
    }
}
