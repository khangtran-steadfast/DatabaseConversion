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
    
    public partial class Workbook_Notes
    {
        public int wor_not_id { get; set; }
        public Nullable<int> wor_not_wor_id { get; set; }
        public string wor_not_created_who { get; set; }
        public System.DateTime wor_not_created_when { get; set; }
        public string wor_not_updated_who { get; set; }
        public Nullable<System.DateTime> wor_not_updated_when { get; set; }
        public string wor_not_note { get; set; }
        public string wor_not_contact { get; set; }
        public string wor_not_subject { get; set; }
        public string wor_not_phone { get; set; }
        public string wor_not_mobile { get; set; }
        public string wor_not_email { get; set; }
        public byte[] RowVersion { get; set; }
        public Nullable<int> wor_not_parent_id { get; set; }
    
        public virtual policies policies { get; set; }
        public virtual workbooks workbooks { get; set; }
    }
}
