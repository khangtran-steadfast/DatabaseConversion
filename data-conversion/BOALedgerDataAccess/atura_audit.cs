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
    
    public partial class atura_audit
    {
        public int aud_id { get; set; }
        public int aud_op_id { get; set; }
        public string aud_syslogin { get; set; }
        public System.DateTime aud_date_time { get; set; }
        public int aud_tbl_id { get; set; }
        public int aud_rec_id { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual entities_a entities_a { get; set; }
    }
}
