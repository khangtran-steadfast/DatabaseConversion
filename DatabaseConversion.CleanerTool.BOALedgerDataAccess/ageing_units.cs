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
    
    public partial class ageing_units
    {
        public ageing_units()
        {
            this.gl_ledgers = new HashSet<gl_ledgers>();
        }
    
        public int ageuni_id { get; set; }
        public string ageuni_created_who { get; set; }
        public System.DateTime ageuni_created_when { get; set; }
        public string ageuni_updated_who { get; set; }
        public Nullable<System.DateTime> ageuni_updated_when { get; set; }
        public string ageuni_name { get; set; }
        public string ageuni_desc { get; set; }
        public bool ageuni_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<gl_ledgers> gl_ledgers { get; set; }
    }
}
