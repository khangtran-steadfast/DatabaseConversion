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
    
    public partial class sunrise_products
    {
        public int sunpro_id { get; set; }
        public string sunpro_created_who { get; set; }
        public System.DateTime sunpro_created_when { get; set; }
        public string sunpro_updated_who { get; set; }
        public Nullable<System.DateTime> sunpro_updated_when { get; set; }
        public int sunpro_parent_id { get; set; }
        public string sunpro_name { get; set; }
        public string sunpro_desc { get; set; }
        public bool sunpro_inactive { get; set; }
        public string sunpro_genins_wor_id { get; set; }
        public Nullable<int> sunpro_server_code { get; set; }
        public string sunpro_email_name { get; set; }
        public string sunpro_email_address { get; set; }
        public string sunpro_particulars_font { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual sunrise_insurers sunrise_insurers { get; set; }
    }
}
