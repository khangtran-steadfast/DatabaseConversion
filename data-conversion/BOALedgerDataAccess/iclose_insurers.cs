//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOALedgerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class iclose_insurers
    {
        public iclose_insurers()
        {
            this.iclose_products = new HashSet<iclose_products>();
        }
    
        public int icloseins_id { get; set; }
        public string icloseins_created_who { get; set; }
        public System.DateTime icloseins_created_when { get; set; }
        public string icloseins_updated_who { get; set; }
        public Nullable<System.DateTime> icloseins_updated_when { get; set; }
        public string icloseins_name { get; set; }
        public string icloseins_desc { get; set; }
        public bool icloseins_inactive { get; set; }
        public Nullable<int> icloseins_insurer_id { get; set; }
        public string icloseins_receiver_id { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual ICollection<iclose_products> iclose_products { get; set; }
    }
}
