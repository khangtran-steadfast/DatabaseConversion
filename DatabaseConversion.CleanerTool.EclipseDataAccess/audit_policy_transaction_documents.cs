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
    
    public partial class audit_policy_transaction_documents
    {
        public int audit_poltrado_id { get; set; }
        public int poltrado_id { get; set; }
        public string poltrado_created_who { get; set; }
        public System.DateTime poltrado_created_when { get; set; }
        public string poltrado_updated_who { get; set; }
        public Nullable<System.DateTime> poltrado_updated_when { get; set; }
        public int poltrado_parent_id { get; set; }
        public string poltrado_name { get; set; }
        public string poltrado_desc { get; set; }
        public Nullable<int> poltrado_sort { get; set; }
        public bool poltrado_inactive { get; set; }
        public Nullable<int> poltrado_type { get; set; }
        public byte[] poltrado_object { get; set; }
    }
}
