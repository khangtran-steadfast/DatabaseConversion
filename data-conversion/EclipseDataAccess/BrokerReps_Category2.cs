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
    
    public partial class BrokerReps_Category2
    {
        public BrokerReps_Category2()
        {
            this.entities = new HashSet<entities>();
        }
    
        public int brcat2_id { get; set; }
        public string brcat2_created_who { get; set; }
        public System.DateTime brcat2_created_when { get; set; }
        public string brcat2_updated_who { get; set; }
        public Nullable<System.DateTime> brcat2_updated_when { get; set; }
        public string brcat2_name { get; set; }
        public string brcat2_desc { get; set; }
        public int brcat2_sort { get; set; }
        public bool brcat2_inactive { get; set; }
    
        public virtual ICollection<entities> entities { get; set; }
    }
}
