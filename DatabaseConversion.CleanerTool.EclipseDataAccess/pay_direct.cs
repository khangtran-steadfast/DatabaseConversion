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
    
    public partial class pay_direct
    {
        public int pd_id { get; set; }
        public int pd_inv_trans_id { get; set; }
        public int pd_insurer_id { get; set; }
        public int pd_client_id { get; set; }
        public decimal pd_amount { get; set; }
        public Nullable<int> pd_trans_id { get; set; }
        public string pd_created_who { get; set; }
        public Nullable<System.DateTime> pd_created_when { get; set; }
        public string pd_updated_who { get; set; }
        public Nullable<System.DateTime> pd_updated_when { get; set; }
    }
}
