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
    
    public partial class client_account_types
    {
        public client_account_types()
        {
            this.profile = new HashSet<profile>();
            this.WorkbookMappings_Client = new HashSet<WorkbookMappings_Client>();
        }
    
        public int cliaccty_id { get; set; }
        public string cliaccty_created_who { get; set; }
        public System.DateTime cliaccty_created_when { get; set; }
        public string cliaccty_updated_who { get; set; }
        public Nullable<System.DateTime> cliaccty_updated_when { get; set; }
        public string cliaccty_name { get; set; }
        public string cliaccty_desc { get; set; }
        public Nullable<int> cliaccty_sort { get; set; }
        public bool cliaccty_inactive { get; set; }
        public bool cliaccty_close_on_billing { get; set; }
        public bool cliaccty_close_on_cash { get; set; }
    
        public virtual ICollection<profile> profile { get; set; }
        public virtual ICollection<WorkbookMappings_Client> WorkbookMappings_Client { get; set; }
    }
}
