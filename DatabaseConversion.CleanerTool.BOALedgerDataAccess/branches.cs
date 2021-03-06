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
    
    public partial class branches
    {
        public branches()
        {
            this.profile = new HashSet<profile>();
            this.branches1 = new HashSet<branches>();
        }
    
        public int bra_id { get; set; }
        public string bra_created_who { get; set; }
        public System.DateTime bra_created_when { get; set; }
        public string bra_updated_who { get; set; }
        public Nullable<System.DateTime> bra_updated_when { get; set; }
        public string bra_name { get; set; }
        public string bra_desc { get; set; }
        public bool bra_inactive { get; set; }
        public string bra_address_1 { get; set; }
        public string bra_address_2 { get; set; }
        public string bra_address_3 { get; set; }
        public string bra_suburb { get; set; }
        public Nullable<int> bra_state { get; set; }
        public string bra_postcode { get; set; }
        public string bra_telephone { get; set; }
        public string bra_telephone_2 { get; set; }
        public string bra_mobile { get; set; }
        public string bra_facsimile { get; set; }
        public string bra_email { get; set; }
        public string bra_web_site { get; set; }
        public string bra_trading_as { get; set; }
        public Nullable<int> bra_parent_branch { get; set; }
        public Nullable<short> bra_asic_branch { get; set; }
        public Nullable<int> bra_cr_closing_opt { get; set; }
        public Nullable<int> bra_cr_receipting_opt { get; set; }
        public string bra_branch_id { get; set; }
        public string bra_company_name { get; set; }
        public string bra_ABN { get; set; }
        public string bra_logo { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual states states { get; set; }
        public virtual ICollection<profile> profile { get; set; }
        public virtual ICollection<branches> branches1 { get; set; }
        public virtual branches branches2 { get; set; }
    }
}
