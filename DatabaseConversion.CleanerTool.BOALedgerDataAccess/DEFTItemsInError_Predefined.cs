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
    
    public partial class DEFTItemsInError_Predefined
    {
        public int deftiiep_id { get; set; }
        public int deftiiep_deft_item_id { get; set; }
        public int deftiiep_predefined_error_id { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual DEFTItems DEFTItems { get; set; }
        public virtual DEFTPredefinedErrors DEFTPredefinedErrors { get; set; }
    }
}
