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
    
    public partial class brokerlink_insurers
    {
        public brokerlink_insurers()
        {
            this.brokerlink_products = new HashSet<brokerlink_products>();
        }
    
        public int broins_id { get; set; }
        public string broins_created_who { get; set; }
        public System.DateTime broins_created_when { get; set; }
        public string broins_updated_who { get; set; }
        public Nullable<System.DateTime> broins_updated_when { get; set; }
        public string broins_name { get; set; }
        public string broins_desc { get; set; }
        public Nullable<int> broins_sort { get; set; }
        public bool broins_inactive { get; set; }
        public Nullable<int> broins_insurer { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual ICollection<brokerlink_products> brokerlink_products { get; set; }
    }
}