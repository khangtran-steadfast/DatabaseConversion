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
    
    public partial class Claim_Catastrophe_Code
    {
        public Claim_Catastrophe_Code()
        {
            this.claims = new HashSet<claims>();
        }
    
        public int cata_id { get; set; }
        public string cata_created_who { get; set; }
        public System.DateTime cata_created_when { get; set; }
        public string cata_updated_who { get; set; }
        public Nullable<System.DateTime> cata_updated_when { get; set; }
        public string cata_name { get; set; }
        public string cata_desc { get; set; }
        public int cata_sort { get; set; }
        public bool cata_inactive { get; set; }
    
        public virtual ICollection<claims> claims { get; set; }
    }
}
