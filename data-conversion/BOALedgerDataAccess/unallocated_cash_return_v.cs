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
    
    public partial class unallocated_cash_return_v
    {
        public string Ent_Name { get; set; }
        public int tran_id { get; set; }
        public System.DateTime tran_time { get; set; }
        public string tran_type { get; set; }
        public string particulars { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> bal_amount { get; set; }
        public short SPID { get; set; }
        public Nullable<int> Ent_ID { get; set; }
    }
}
