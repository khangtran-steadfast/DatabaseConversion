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
    
    public partial class ClausePermissions
    {
        public int clause_permission_id { get; set; }
        public int clause_id { get; set; }
        public int insurer_id { get; set; }
        public int COB_id { get; set; }
        public string COBSection_name { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual clauses clauses { get; set; }
    }
}
