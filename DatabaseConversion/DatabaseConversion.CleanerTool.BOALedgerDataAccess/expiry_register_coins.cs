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
    
    public partial class expiry_register_coins
    {
        public Nullable<int> pol_tran_id { get; set; }
        public int coins_parent_id { get; set; }
        public Nullable<int> coins_insurer_id { get; set; }
        public string coinsurer_name { get; set; }
        public short SPID { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
