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
    
    public partial class sources_of_business
    {
        public sources_of_business()
        {
            this.profile = new HashSet<profile>();
            this.workbooks = new HashSet<workbooks>();
        }
    
        public int souofbus_id { get; set; }
        public string souofbus_created_who { get; set; }
        public System.DateTime souofbus_created_when { get; set; }
        public string souofbus_updated_who { get; set; }
        public Nullable<System.DateTime> souofbus_updated_when { get; set; }
        public string souofbus_name { get; set; }
        public string souofbus_desc { get; set; }
        public bool souofbus_inactive { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<profile> profile { get; set; }
        public virtual ICollection<workbooks> workbooks { get; set; }
    }
}
