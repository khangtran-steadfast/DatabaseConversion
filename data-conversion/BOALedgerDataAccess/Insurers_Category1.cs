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
    
    public partial class Insurers_Category1
    {
        public Insurers_Category1()
        {
            this.entities = new HashSet<entities>();
        }
    
        public int incat1_id { get; set; }
        public string incat1_created_who { get; set; }
        public System.DateTime incat1_created_when { get; set; }
        public string incat1_updated_who { get; set; }
        public Nullable<System.DateTime> incat1_updated_when { get; set; }
        public string incat1_name { get; set; }
        public string incat1_desc { get; set; }
        public bool incat1_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<entities> entities { get; set; }
    }
}
