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
    
    public partial class CustomDropDownListTableItemsItems
    {
        public int Id { get; set; }
        public int CustomDropDownListTableItemId { get; set; }
        public string Item { get; set; }
        public int Position { get; set; }
    
        public virtual CustomDropDownListTableItems CustomDropDownListTableItems { get; set; }
    }
}
