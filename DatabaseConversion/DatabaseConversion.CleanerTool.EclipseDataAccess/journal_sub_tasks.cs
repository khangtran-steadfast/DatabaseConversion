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
    
    public partial class journal_sub_tasks
    {
        public int jousubta_id { get; set; }
        public int jousubta_parent_id { get; set; }
        public string jousubta_created_who { get; set; }
        public System.DateTime jousubta_created_when { get; set; }
        public string jousubta_updated_who { get; set; }
        public Nullable<System.DateTime> jousubta_updated_when { get; set; }
        public Nullable<int> jousubta_duration { get; set; }
        public Nullable<System.DateTime> jousubta_date { get; set; }
        public string jousubta_initiated_by { get; set; }
        public string jousubta_brief_description { get; set; }
        public Nullable<int> jousubta_document { get; set; }
        public byte[] jousubta_image { get; set; }
        public string Fname { get; set; }
        public Nullable<int> jousubta_HasDocument { get; set; }
    
        public virtual gen_ins_documents gen_ins_documents { get; set; }
        public virtual journals journals { get; set; }
    }
}