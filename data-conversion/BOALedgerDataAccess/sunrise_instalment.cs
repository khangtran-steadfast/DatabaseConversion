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
    
    public partial class sunrise_instalment
    {
        public sunrise_instalment()
        {
            this.sunrise_instalment_payments = new HashSet<sunrise_instalment_payments>();
        }
    
        public int suninstal_id { get; set; }
        public int suninstal_wor_id { get; set; }
        public Nullable<int> suninstal_previous_wor_id { get; set; }
        public string suninstal_frequency { get; set; }
        public bool suninstal_indicator_only { get; set; }
        public int suninstal_no_of_instalments { get; set; }
        public string suninstal_comm_payment_method { get; set; }
        public bool suninstal_cease_instalments { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<sunrise_instalment_payments> sunrise_instalment_payments { get; set; }
        public virtual workbooks workbooks { get; set; }
    }
}
