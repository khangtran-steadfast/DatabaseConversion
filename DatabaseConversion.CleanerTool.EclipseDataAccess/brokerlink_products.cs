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
    
    public partial class brokerlink_products
    {
        public int bropro_id { get; set; }
        public string bropro_created_who { get; set; }
        public System.DateTime bropro_created_when { get; set; }
        public string bropro_updated_who { get; set; }
        public Nullable<System.DateTime> bropro_updated_when { get; set; }
        public int bropro_parent_id { get; set; }
        public string bropro_name { get; set; }
        public string bropro_desc { get; set; }
        public Nullable<int> bropro_sort { get; set; }
        public bool bropro_inactive { get; set; }
        public Nullable<int> bropro_workbook { get; set; }
        public Nullable<int> bropro_available_actions { get; set; }
    
        public virtual brokerlink_insurers brokerlink_insurers { get; set; }
        public virtual general_insurance_workbooks general_insurance_workbooks { get; set; }
    }
}
