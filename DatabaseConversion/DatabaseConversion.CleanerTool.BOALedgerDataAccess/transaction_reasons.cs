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
    
    public partial class transaction_reasons
    {
        public int trarea_id { get; set; }
        public string trarea_created_who { get; set; }
        public System.DateTime trarea_created_when { get; set; }
        public string trarea_updated_who { get; set; }
        public Nullable<System.DateTime> trarea_updated_when { get; set; }
        public int trarea_parent_id { get; set; }
        public string trarea_name { get; set; }
        public string trarea_desc { get; set; }
        public bool trarea_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual transaction_types transaction_types { get; set; }
    }
}
