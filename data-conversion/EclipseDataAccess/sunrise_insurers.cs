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
    
    public partial class sunrise_insurers
    {
        public sunrise_insurers()
        {
            this.sunrise_products = new HashSet<sunrise_products>();
        }
    
        public int sunins_id { get; set; }
        public string sunins_created_who { get; set; }
        public System.DateTime sunins_created_when { get; set; }
        public string sunins_updated_who { get; set; }
        public Nullable<System.DateTime> sunins_updated_when { get; set; }
        public string sunins_name { get; set; }
        public string sunins_desc { get; set; }
        public Nullable<int> sunins_sort { get; set; }
        public bool sunins_inactive { get; set; }
        public Nullable<int> sunins_insurer_id { get; set; }
        public string sunins_transmission_code { get; set; }
    
        public virtual entities entities { get; set; }
        public virtual ICollection<sunrise_products> sunrise_products { get; set; }
    }
}