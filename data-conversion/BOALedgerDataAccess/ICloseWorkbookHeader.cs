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
    
    public partial class ICloseWorkbookHeader
    {
        public int WorkbookHeaderId { get; set; }
        public int wor_id { get; set; }
        public Nullable<int> Insurer { get; set; }
        public string UKI { get; set; }
        public Nullable<bool> Bound { get; set; }
        public Nullable<bool> Lapsed { get; set; }
        public Nullable<bool> Closed { get; set; }
        public Nullable<bool> ParticularsDownloaded { get; set; }
        public string QuoteStatus { get; set; }
        public string QuoteNumberId { get; set; }
        public string ContractStatus { get; set; }
        public string UQI { get; set; }
        public string BindStatus { get; set; }
        public string PreviousUKI { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual workbooks workbooks { get; set; }
    }
}
