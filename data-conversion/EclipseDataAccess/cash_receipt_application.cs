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
    
    public partial class cash_receipt_application
    {
        public int Cra_id { get; set; }
        public int Cra_Rcpt_id { get; set; }
        public Nullable<int> Cra_Pol_Trans_id { get; set; }
        public Nullable<decimal> Cra_Old_Balance { get; set; }
        public Nullable<decimal> Cra_Applied_Amount { get; set; }
        public Nullable<decimal> Cra_New_Balance { get; set; }
        public string cra_created_who { get; set; }
        public Nullable<System.DateTime> cra_created_when { get; set; }
    
        public virtual cash_receipts cash_receipts { get; set; }
    }
}