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
    
    public partial class HomeValuables
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<decimal> SumInsured { get; set; }
        public int HomeId { get; set; }
    
        public virtual Home Home { get; set; }
    }
}