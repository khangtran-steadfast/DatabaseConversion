//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.CleanerTool.BOALedgerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class apra_class_of_business
    {
        public apra_class_of_business()
        {
            this.gen_ins_classes_of_business = new HashSet<gen_ins_classes_of_business>();
        }
    
        public int apracob_id { get; set; }
        public string apracob_created_who { get; set; }
        public System.DateTime apracob_created_when { get; set; }
        public string apracob_updated_who { get; set; }
        public Nullable<System.DateTime> apracob_updated_when { get; set; }
        public string apracob_name { get; set; }
        public string apracob_desc { get; set; }
        public bool apracob_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<gen_ins_classes_of_business> gen_ins_classes_of_business { get; set; }
    }
}
