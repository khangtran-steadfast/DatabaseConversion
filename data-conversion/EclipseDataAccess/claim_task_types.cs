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
    
    public partial class claim_task_types
    {
        public claim_task_types()
        {
            this.claim_tasks = new HashSet<claim_tasks>();
            this.WorkbookMappings_ClaimTask = new HashSet<WorkbookMappings_ClaimTask>();
        }
    
        public int clatasty_id { get; set; }
        public string clatasty_created_who { get; set; }
        public System.DateTime clatasty_created_when { get; set; }
        public string clatasty_updated_who { get; set; }
        public Nullable<System.DateTime> clatasty_updated_when { get; set; }
        public string clatasty_name { get; set; }
        public string clatasty_desc { get; set; }
        public int clatasty_sort { get; set; }
        public bool clatasty_inactive { get; set; }
    
        public virtual ICollection<claim_tasks> claim_tasks { get; set; }
        public virtual ICollection<WorkbookMappings_ClaimTask> WorkbookMappings_ClaimTask { get; set; }
    }
}
