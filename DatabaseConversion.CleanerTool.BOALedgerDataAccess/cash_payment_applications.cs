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
    
    public partial class cash_payment_applications
    {
        public int cpa_id { get; set; }
        public int cpa_paybat_id { get; set; }
        public int cpa_inc_id { get; set; }
        public decimal cpa_amount { get; set; }
        public Nullable<short> cpa_approved { get; set; }
        public Nullable<int> cpa_ledger { get; set; }
        public Nullable<int> cpa_entity_id { get; set; }
        public Nullable<decimal> cpa_orig_amount { get; set; }
        public Nullable<short> cpa_adjust { get; set; }
        public Nullable<decimal> cpa_earlier_paid { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual gl_ledgers gl_ledgers { get; set; }
        public virtual transactions transactions { get; set; }
        public virtual payment_batch payment_batch { get; set; }
    }
}
