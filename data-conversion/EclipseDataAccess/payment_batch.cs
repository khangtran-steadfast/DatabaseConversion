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
    
    public partial class payment_batch
    {
        public payment_batch()
        {
            this.cash_payment_applications = new HashSet<cash_payment_applications>();
            this.cash_payments = new HashSet<cash_payments>();
        }
    
        public int paybat_id { get; set; }
        public System.DateTime paybat_time { get; set; }
        public int paybat_status { get; set; }
        public Nullable<int> paybat_ledger { get; set; }
        public Nullable<int> paybat_entity_id { get; set; }
    
        public virtual ICollection<cash_payment_applications> cash_payment_applications { get; set; }
        public virtual ICollection<cash_payments> cash_payments { get; set; }
        public virtual entities entities { get; set; }
        public virtual ledgers ledgers { get; set; }
    }
}
