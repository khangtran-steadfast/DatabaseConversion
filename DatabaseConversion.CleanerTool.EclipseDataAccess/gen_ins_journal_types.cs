//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.CleanerTool.EclipseDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class gen_ins_journal_types
    {
        public gen_ins_journal_types()
        {
            this.journals = new HashSet<journals>();
        }
    
        public int genjouty_id { get; set; }
        public string genjouty_created_who { get; set; }
        public System.DateTime genjouty_created_when { get; set; }
        public string genjouty_updated_who { get; set; }
        public Nullable<System.DateTime> genjouty_updated_when { get; set; }
        public string genjouty_name { get; set; }
        public string genjouty_desc { get; set; }
        public int genjouty_sort { get; set; }
        public bool genjouty_inactive { get; set; }
    
        public virtual ICollection<journals> journals { get; set; }
    }
}
