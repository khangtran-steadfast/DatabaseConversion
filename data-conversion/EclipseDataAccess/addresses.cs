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
    
    public partial class addresses
    {
        public int add_id { get; set; }
        public int add_parent_id { get; set; }
        public string add_created_who { get; set; }
        public System.DateTime add_created_when { get; set; }
        public string add_updated_who { get; set; }
        public Nullable<System.DateTime> add_updated_when { get; set; }
        public Nullable<int> add_duration { get; set; }
        public bool add_primary_address { get; set; }
        public Nullable<int> add_address_type { get; set; }
        public string add_address_1 { get; set; }
        public string add_address_2 { get; set; }
        public string add_address_3 { get; set; }
        public string add_suburb { get; set; }
        public Nullable<int> add_state { get; set; }
        public string add_postcode { get; set; }
        public string add_telephone { get; set; }
        public string add_telephone_2 { get; set; }
        public string add_facsimile { get; set; }
        public Nullable<byte> add_update_flag { get; set; }
        public string add_latitude { get; set; }
        public string add_longitude { get; set; }
    
        public virtual address_types address_types { get; set; }
        public virtual entities entities { get; set; }
        public virtual states states { get; set; }
    }
}