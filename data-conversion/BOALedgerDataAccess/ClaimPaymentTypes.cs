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
    
    public partial class ClaimPaymentTypes
    {
        public ClaimPaymentTypes()
        {
            this.ClaimPaymentDetails = new HashSet<ClaimPaymentDetails>();
        }
    
        public int clatype_id { get; set; }
        public string clatype_created_who { get; set; }
        public System.DateTime clatype_created_when { get; set; }
        public string clatype_updated_who { get; set; }
        public Nullable<System.DateTime> clatype_updated_when { get; set; }
        public string clatype_name { get; set; }
        public string clatype_desc { get; set; }
        public bool clatype_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<ClaimPaymentDetails> ClaimPaymentDetails { get; set; }
    }
}
