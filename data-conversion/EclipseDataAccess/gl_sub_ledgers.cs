//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EclipseDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class gl_sub_ledgers
    {
        public gl_sub_ledgers()
        {
            this.gl_journal_items = new HashSet<gl_journal_items>();
        }
    
        public int glsl_id { get; set; }
        public int glsl_glac_num { get; set; }
        public string glsl_name { get; set; }
        public Nullable<int> glsl_entity_id { get; set; }
        public string glsl_active { get; set; }
        public Nullable<decimal> glsl_balance { get; set; }
        public string glsl_created_who { get; set; }
        public Nullable<System.DateTime> glsl_created_when { get; set; }
        public string glsl_updated_who { get; set; }
        public Nullable<System.DateTime> glsl_updated_when { get; set; }
    
        public virtual gl_accounts gl_accounts { get; set; }
        public virtual ICollection<gl_journal_items> gl_journal_items { get; set; }
    }
}
