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
    
    public partial class DEFTStatuses
    {
        public DEFTStatuses()
        {
            this.DEFTItems = new HashSet<DEFTItems>();
        }
    
        public int deftsta_id { get; set; }
        public string deftsta_description { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<DEFTItems> DEFTItems { get; set; }
    }
}
