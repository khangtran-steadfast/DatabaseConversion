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
    
    public partial class remittance_advice_formats
    {
        public remittance_advice_formats()
        {
            this.insurer_profiles = new HashSet<insurer_profiles>();
        }
    
        public int rafmt_id { get; set; }
        public string rafmt_created_who { get; set; }
        public System.DateTime rafmt_created_when { get; set; }
        public string rafmt_updated_who { get; set; }
        public System.DateTime rafmt_updated_when { get; set; }
        public string rafmt_name { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<insurer_profiles> insurer_profiles { get; set; }
    }
}
