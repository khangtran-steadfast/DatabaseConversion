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
    
    public partial class LandTransit
    {
        public int LandTransitId { get; set; }
        public int WorkbookId { get; set; }
        public Nullable<decimal> SumInsured { get; set; }
        public Nullable<bool> AccidentalDamage { get; set; }
        public string Excess { get; set; }
        public Nullable<bool> EndorsementsApply { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public int PremiumId { get; set; }
        public string Endorsements { get; set; }
        public Nullable<bool> Validated { get; set; }
    
        public virtual workbooks workbooks { get; set; }
        public virtual Premiums Premiums { get; set; }
    }
}
