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
    
    public partial class CustomPercentageTableItems
    {
        public int Id { get; set; }
        public int CustomTableItemId { get; set; }
        public Nullable<decimal> DefaultValue { get; set; }
        public Nullable<decimal> MinimumValue { get; set; }
        public Nullable<decimal> MaximumValue { get; set; }
        public int Precision { get; set; }
        public bool ShowCommas { get; set; }
        public string TextAlignment { get; set; }
    
        public virtual CustomTableItems CustomTableItems { get; set; }
    }
}
