//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.CleanerTool.BOALedgerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class related_entities
    {
        public int relent_id { get; set; }
        public int relent_parent_id { get; set; }
        public string relent_created_who { get; set; }
        public System.DateTime relent_created_when { get; set; }
        public string relent_updated_who { get; set; }
        public Nullable<System.DateTime> relent_updated_when { get; set; }
        public Nullable<int> relent_duration { get; set; }
        public Nullable<int> relent_related_entity_types { get; set; }
        public Nullable<int> relent_related_entity { get; set; }
        public string relent_notes { get; set; }
        public string relent_contact { get; set; }
        public string relent_telephone { get; set; }
        public string relent_facsimile { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual entities entities1 { get; set; }
        public virtual related_entity_types related_entity_types { get; set; }
    }
}
