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
    
    public partial class limited_exemptions
    {
        public limited_exemptions()
        {
            this.exemption_types = new HashSet<exemption_types>();
            this.policies = new HashSet<policies>();
            this.workbooks = new HashSet<workbooks>();
        }
    
        public int limex_id { get; set; }
        public string limex_created_who { get; set; }
        public System.DateTime limex_created_when { get; set; }
        public string limex_updated_who { get; set; }
        public Nullable<System.DateTime> limex_updated_when { get; set; }
        public string limex_name { get; set; }
        public string limex_desc { get; set; }
        public bool limex_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<exemption_types> exemption_types { get; set; }
        public virtual ICollection<policies> policies { get; set; }
        public virtual ICollection<workbooks> workbooks { get; set; }
    }
}
