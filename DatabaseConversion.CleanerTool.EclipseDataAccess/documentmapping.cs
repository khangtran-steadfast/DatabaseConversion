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
    
    public partial class documentmapping
    {
        public int doc_id { get; set; }
        public string doc_created_who { get; set; }
        public System.DateTime doc_created_when { get; set; }
        public string doc_updated_who { get; set; }
        public Nullable<System.DateTime> doc_updated_when { get; set; }
        public string doc_name { get; set; }
        public string doc_desc { get; set; }
        public Nullable<int> doc_sort { get; set; }
        public bool doc_inactive { get; set; }
        public Nullable<int> doc_classofbusiness { get; set; }
        public Nullable<int> doc_bodydocumentid { get; set; }
    
        public virtual gen_ins_classes_of_business gen_ins_classes_of_business { get; set; }
        public virtual general_insurance_workbooks general_insurance_workbooks { get; set; }
    }
}
