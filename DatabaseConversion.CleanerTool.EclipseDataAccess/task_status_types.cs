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
    
    public partial class task_status_types
    {
        public task_status_types()
        {
            this.tasks = new HashSet<tasks>();
        }
    
        public int tasstaty_id { get; set; }
        public string tasstaty_created_who { get; set; }
        public System.DateTime tasstaty_created_when { get; set; }
        public string tasstaty_updated_who { get; set; }
        public Nullable<System.DateTime> tasstaty_updated_when { get; set; }
        public string tasstaty_name { get; set; }
        public string tasstaty_desc { get; set; }
        public int tasstaty_sort { get; set; }
        public bool tasstaty_inactive { get; set; }
        public bool tasstaty_closed { get; set; }
        public Nullable<int> tasstaty_ODcolour { get; set; }
        public Nullable<int> tasstaty_NotDuecolour { get; set; }
        public Nullable<int> tasstaty_Backgroundcolour { get; set; }
        public Nullable<int> tasstaty_ODBackgroundcolour { get; set; }
    
        public virtual ICollection<tasks> tasks { get; set; }
    }
}
