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
    
    public partial class Claim_Notes
    {
        public int Claim_not_id { get; set; }
        public int Claim_not_parent_id { get; set; }
        public string Claim_not_created_who { get; set; }
        public System.DateTime Claim_not_created_when { get; set; }
        public string Claim_not_updated_who { get; set; }
        public Nullable<System.DateTime> Claim_not_updated_when { get; set; }
        public string Claim_not_note { get; set; }
        public string Claim_not_Contact { get; set; }
        public string Claim_not_Subject { get; set; }
        public string Claim_not_phone { get; set; }
        public string Claim_not_mobile { get; set; }
        public string Claim_not_email { get; set; }
    
        public virtual claim_tasks claim_tasks { get; set; }
    }
}