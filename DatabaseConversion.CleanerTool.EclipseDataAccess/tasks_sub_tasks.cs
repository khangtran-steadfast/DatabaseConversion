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
    
    public partial class tasks_sub_tasks
    {
        public int tassubta_id { get; set; }
        public int tassubta_parent_id { get; set; }
        public string tassubta_created_who { get; set; }
        public System.DateTime tassubta_created_when { get; set; }
        public string tassubta_updated_who { get; set; }
        public Nullable<System.DateTime> tassubta_updated_when { get; set; }
        public Nullable<int> tassubta_duration { get; set; }
        public Nullable<System.DateTime> tassubta_date { get; set; }
        public string tassubta_initiated_by { get; set; }
        public string tassubta_brief_description { get; set; }
        public Nullable<int> tassubta_document { get; set; }
        public byte[] tassubta_image { get; set; }
        public string Fname { get; set; }
        public Nullable<int> tassubta_HasDocument { get; set; }
    
        public virtual task_documents task_documents { get; set; }
        public virtual tasks tasks { get; set; }
    }
}
