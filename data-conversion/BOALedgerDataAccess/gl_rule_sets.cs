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
    
    public partial class gl_rule_sets
    {
        public gl_rule_sets()
        {
            this.gl_movements = new HashSet<gl_movements>();
            this.gl_rules = new HashSet<gl_rules>();
        }
    
        public string glrs_set { get; set; }
        public string glrs_name { get; set; }
        public string glrs_created_who { get; set; }
        public System.DateTime glrs_created_when { get; set; }
        public string glrs_updated_who { get; set; }
        public Nullable<System.DateTime> glrs_updated_when { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<gl_movements> gl_movements { get; set; }
        public virtual ICollection<gl_rules> gl_rules { get; set; }
    }
}
