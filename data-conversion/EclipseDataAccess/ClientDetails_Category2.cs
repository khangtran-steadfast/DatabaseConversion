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
    
    public partial class ClientDetails_Category2
    {
        public ClientDetails_Category2()
        {
            this.entities = new HashSet<entities>();
        }
    
        public int cdcat2_id { get; set; }
        public string cdcat2_created_who { get; set; }
        public System.DateTime cdcat2_created_when { get; set; }
        public string cdcat2_updated_who { get; set; }
        public Nullable<System.DateTime> cdcat2_updated_when { get; set; }
        public string cdcat2_name { get; set; }
        public string cdcat2_desc { get; set; }
        public int cdcat2_sort { get; set; }
        public bool cdcat2_inactive { get; set; }
    
        public virtual ICollection<entities> entities { get; set; }
    }
}
