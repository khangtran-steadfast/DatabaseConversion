//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOALedgerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class premium_funding
    {
        public premium_funding()
        {
            this.fund_policies2 = new HashSet<fund_policies2>();
        }
    
        public int prefun_id { get; set; }
        public string prefun_created_who { get; set; }
        public Nullable<System.DateTime> prefun_created_when { get; set; }
        public string prefun_updated_who { get; set; }
        public Nullable<System.DateTime> prefun_updated_when { get; set; }
        public string prefun_name { get; set; }
        public string prefun_desc { get; set; }
        public bool prefun_inactive { get; set; }
        public string prefun_url { get; set; }
        public string prefun_licence_expires_on { get; set; }
        public Nullable<int> prefun_number_of_users { get; set; }
        public string prefun_activation_key { get; set; }
        public string prefun_standalone { get; set; }
        public string prefun_login { get; set; }
        public string prefun_password { get; set; }
        public string prefun_funder_code { get; set; }
        public string prefun_interface { get; set; }
        public string prefun_web_dev_stage { get; set; }
        public bool prefun_payment { get; set; }
        public bool prefun_Attvest_Bank_File { get; set; }
        public bool prefun_Online_Quoting { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<fund_policies2> fund_policies2 { get; set; }
    }
}