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
    
    public partial class WorkbookMappings_BrokerRep
    {
        public int brworma_id { get; set; }
        public string brworma_name { get; set; }
        public int brworma_wor_format { get; set; }
        public Nullable<int> brworma_roles { get; set; }
    
        public virtual CustomWorkbooks CustomWorkbooks { get; set; }
    }
}
