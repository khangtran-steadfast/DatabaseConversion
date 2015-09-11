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
    
    public partial class gl_ledgers
    {
        public gl_ledgers()
        {
            this.cash_payment_applications = new HashSet<cash_payment_applications>();
            this.balances = new HashSet<balances>();
            this.transaction_set_items = new HashSet<transaction_set_items>();
            this.payment_batch = new HashSet<payment_batch>();
        }
    
        public int led_id { get; set; }
        public string led_created_who { get; set; }
        public System.DateTime led_created_when { get; set; }
        public string led_updated_who { get; set; }
        public Nullable<System.DateTime> led_updated_when { get; set; }
        public string led_name { get; set; }
        public string led_desc { get; set; }
        public bool led_inactive { get; set; }
        public Nullable<int> led_ageing_units { get; set; }
        public string led_period_0_caption { get; set; }
        public string led_period_1_caption { get; set; }
        public string led_period_2_caption { get; set; }
        public string led_period_3_caption { get; set; }
        public string led_period_4_caption { get; set; }
        public string led_period_5_caption { get; set; }
        public Nullable<short> led_period_1_units { get; set; }
        public Nullable<short> led_period_2_units { get; set; }
        public Nullable<short> led_period_3_units { get; set; }
        public Nullable<short> led_period_4_units { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ageing_units ageing_units { get; set; }
        public virtual ICollection<cash_payment_applications> cash_payment_applications { get; set; }
        public virtual ICollection<balances> balances { get; set; }
        public virtual ICollection<transaction_set_items> transaction_set_items { get; set; }
        public virtual ICollection<payment_batch> payment_batch { get; set; }
    }
}
