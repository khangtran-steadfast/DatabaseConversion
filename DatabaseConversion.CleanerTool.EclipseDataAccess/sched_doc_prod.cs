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
    
    public partial class sched_doc_prod
    {
        public int scheddoc_id { get; set; }
        public string scheddoc_created_who { get; set; }
        public System.DateTime scheddoc_created_when { get; set; }
        public string scheddoc_updated_who { get; set; }
        public Nullable<System.DateTime> scheddoc_updated_when { get; set; }
        public string scheddoc_name { get; set; }
        public string scheddoc_desc { get; set; }
        public Nullable<int> scheddoc_sort { get; set; }
        public bool scheddoc_inactive { get; set; }
        public Nullable<int> scheddoc_document { get; set; }
        public string scheddoc_query { get; set; }
        public Nullable<int> scheddoc_standard_query { get; set; }
        public string scheddoc_status { get; set; }
        public Nullable<short> scheddoc_enabled { get; set; }
    
        public virtual gen_ins_documents gen_ins_documents { get; set; }
        public virtual sched_doc_queries sched_doc_queries { get; set; }
    }
}
