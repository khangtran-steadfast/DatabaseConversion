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
    
    public partial class notes
    {
        public int not_id { get; set; }
        public int not_parent_id { get; set; }
        public string not_created_who { get; set; }
        public System.DateTime not_created_when { get; set; }
        public string not_updated_who { get; set; }
        public Nullable<System.DateTime> not_updated_when { get; set; }
        public Nullable<int> not_duration { get; set; }
        public bool not_closed { get; set; }
        public string not_note { get; set; }
        public string not_summary { get; set; }
        public byte[] not_object { get; set; }
        public Nullable<System.DateTime> not_followup_date { get; set; }
        public string not_followup_action { get; set; }
        public string not_queue { get; set; }
        public string not_Contact { get; set; }
        public string not_Subject { get; set; }
        public string Fname { get; set; }
        public string not_phone { get; set; }
        public string not_mobile { get; set; }
        public string not_email { get; set; }
        public Nullable<int> not_priority { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual priorities priorities { get; set; }
    }
}
