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
    
    public partial class financial_institution
    {
        public financial_institution()
        {
            this.banking = new HashSet<banking>();
        }
    
        public int finins_id { get; set; }
        public string finins_name { get; set; }
        public string finins_branch { get; set; }
        public string finins_acc_name { get; set; }
        public string finins_acc_bsb { get; set; }
        public string finins_acc_no { get; set; }
        public Nullable<bool> finins_inactive { get; set; }
        public string finins_created_who { get; set; }
        public System.DateTime finins_created_when { get; set; }
        public string finins_updated_who { get; set; }
        public Nullable<System.DateTime> finins_updated_when { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<banking> banking { get; set; }
    }
}
