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
    
    public partial class BrokerFeeDefaultWorkbookType
    {
        public BrokerFeeDefaultWorkbookType()
        {
            this.BrokerFeeDefaults = new HashSet<BrokerFeeDefaults>();
            this.BrokerFeeDefaults1 = new HashSet<BrokerFeeDefaults>();
            this.BrokerFeeDefaults2 = new HashSet<BrokerFeeDefaults>();
            this.BrokerFeeDefaults3 = new HashSet<BrokerFeeDefaults>();
            this.BrokerFeeDefaults4 = new HashSet<BrokerFeeDefaults>();
            this.BrokerFeeDefaults5 = new HashSet<BrokerFeeDefaults>();
        }
    
        public int bfdwt_id { get; set; }
        public bool bfdwt_auto { get; set; }
        public decimal bfdwt_percentage { get; set; }
        public int bfdwt_basisId { get; set; }
        public decimal bfdwt_default { get; set; }
        public decimal bfdwt_minimum { get; set; }
        public decimal bfdwt_maximum { get; set; }
        public bool bfdwt_amend { get; set; }
    
        public virtual ICollection<BrokerFeeDefaults> BrokerFeeDefaults { get; set; }
        public virtual ICollection<BrokerFeeDefaults> BrokerFeeDefaults1 { get; set; }
        public virtual ICollection<BrokerFeeDefaults> BrokerFeeDefaults2 { get; set; }
        public virtual ICollection<BrokerFeeDefaults> BrokerFeeDefaults3 { get; set; }
        public virtual ICollection<BrokerFeeDefaults> BrokerFeeDefaults4 { get; set; }
        public virtual ICollection<BrokerFeeDefaults> BrokerFeeDefaults5 { get; set; }
    }
}
