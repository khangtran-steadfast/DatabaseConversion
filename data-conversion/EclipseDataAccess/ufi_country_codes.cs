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
    
    public partial class ufi_country_codes
    {
        public ufi_country_codes()
        {
            this.entities = new HashSet<entities>();
        }
    
        public int uficoco_id { get; set; }
        public string uficoco_name { get; set; }
        public string uficoco_code { get; set; }
        public string uficoco_created_who { get; set; }
        public System.DateTime uficoco_created_when { get; set; }
        public string uficoco_updated_who { get; set; }
        public Nullable<System.DateTime> uficoco_updated_when { get; set; }
        public string uficoco_desc { get; set; }
        public Nullable<int> uficoco_sort { get; set; }
        public bool uficoco_inactive { get; set; }
    
        public virtual ICollection<entities> entities { get; set; }
    }
}
