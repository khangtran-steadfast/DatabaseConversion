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
    
    public partial class banking
    {
        public banking()
        {
            this.cash_receipts = new HashSet<cash_receipts>();
        }
    
        public int bank_id { get; set; }
        public System.DateTime bank_time { get; set; }
        public int bank_status { get; set; }
        public Nullable<int> bank_financial_institution { get; set; }
    
        public virtual financial_institution financial_institution { get; set; }
        public virtual ICollection<cash_receipts> cash_receipts { get; set; }
    }
}
