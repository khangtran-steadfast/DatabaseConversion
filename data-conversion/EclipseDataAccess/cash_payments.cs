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
    
    public partial class cash_payments
    {
        public int pay_id { get; set; }
        public int pay_parent_id { get; set; }
        public Nullable<int> pay_paybat_id { get; set; }
        public Nullable<int> pay_tran_id { get; set; }
        public decimal pay_amount { get; set; }
        public string pay_cheque_no { get; set; }
        public string pay_particulars { get; set; }
        public Nullable<bool> pay_processed { get; set; }
        public Nullable<System.DateTime> pay_processed_date { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual payment_batch payment_batch { get; set; }
        public virtual transactions transactions { get; set; }
    }
}
