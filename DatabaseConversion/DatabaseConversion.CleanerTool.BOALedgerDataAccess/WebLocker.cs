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
    
    public partial class WebLocker
    {
        public int webLockId { get; set; }
        public string Category { get; set; }
        public Nullable<int> ID { get; set; }
        public string LockID { get; set; }
        public string Username { get; set; }
        public Nullable<System.DateTime> Login_Time { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
