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
    
    public partial class CustomCheckBoxTableItems
    {
        public int Id { get; set; }
        public int CustomTableItemId { get; set; }
        public bool Checked { get; set; }
    
        public virtual CustomTableItems CustomTableItems { get; set; }
    }
}
