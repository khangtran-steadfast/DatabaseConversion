//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.CleanerTool.EclipseDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class fund_policies
    {
        public int prem_id { get; set; }
        public Nullable<int> prem_batch_id { get; set; }
        public Nullable<decimal> prem_pol_id { get; set; }
        public string prem_created_who { get; set; }
        public Nullable<System.DateTime> prem_created_when { get; set; }
        public string prem_updated_who { get; set; }
        public Nullable<System.DateTime> prem_updated_when { get; set; }
    
        public virtual fund_batch fund_batch { get; set; }
    }
}
