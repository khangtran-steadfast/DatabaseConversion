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
    
    public partial class PolicyHeader_Category1
    {
        public PolicyHeader_Category1()
        {
            this.general_insurance = new HashSet<general_insurance>();
        }
    
        public int phcat1_id { get; set; }
        public string phcat1_created_who { get; set; }
        public System.DateTime phcat1_created_when { get; set; }
        public string phcat1_updated_who { get; set; }
        public Nullable<System.DateTime> phcat1_updated_when { get; set; }
        public string phcat1_name { get; set; }
        public string phcat1_desc { get; set; }
        public bool phcat1_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<general_insurance> general_insurance { get; set; }
    }
}
