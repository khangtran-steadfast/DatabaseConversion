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
    
    public partial class claim_sub_tasks
    {
        public int clasubta_id { get; set; }
        public int clasubta_parent_id { get; set; }
        public string clasubta_created_who { get; set; }
        public System.DateTime clasubta_created_when { get; set; }
        public string clasubta_updated_who { get; set; }
        public Nullable<System.DateTime> clasubta_updated_when { get; set; }
        public Nullable<int> clasubta_duration { get; set; }
        public Nullable<System.DateTime> clasubta_date { get; set; }
        public string clasubta_initiated_by { get; set; }
        public string clasubta_brief_description { get; set; }
        public Nullable<int> clasubta_document { get; set; }
        public byte[] clasubta_image { get; set; }
        public string Fname { get; set; }
        public Nullable<int> clasubta_HasDocument { get; set; }
    
        public virtual claim_documents claim_documents { get; set; }
        public virtual claim_tasks claim_tasks { get; set; }
    }
}
