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
    
    public partial class claim_causes
    {
        public claim_causes()
        {
            this.claims = new HashSet<claims>();
        }
    
        public int clacau_id { get; set; }
        public string clacau_created_who { get; set; }
        public System.DateTime clacau_created_when { get; set; }
        public string clacau_updated_who { get; set; }
        public Nullable<System.DateTime> clacau_updated_when { get; set; }
        public string clacau_name { get; set; }
        public string clacau_desc { get; set; }
        public bool clacau_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<claims> claims { get; set; }
    }
}
