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
    
    public partial class BrokerReps_Category3
    {
        public BrokerReps_Category3()
        {
            this.entities = new HashSet<entities>();
        }
    
        public int brcat3_id { get; set; }
        public string brcat3_created_who { get; set; }
        public System.DateTime brcat3_created_when { get; set; }
        public string brcat3_updated_who { get; set; }
        public Nullable<System.DateTime> brcat3_updated_when { get; set; }
        public string brcat3_name { get; set; }
        public string brcat3_desc { get; set; }
        public int brcat3_sort { get; set; }
        public bool brcat3_inactive { get; set; }
    
        public virtual ICollection<entities> entities { get; set; }
    }
}
