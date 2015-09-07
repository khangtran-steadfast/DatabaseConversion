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
    
    public partial class CustomTableItems
    {
        public CustomTableItems()
        {
            this.CustomCheckBoxTableItems = new HashSet<CustomCheckBoxTableItems>();
            this.CustomCurrencyTableItems = new HashSet<CustomCurrencyTableItems>();
            this.CustomDateTableItems = new HashSet<CustomDateTableItems>();
            this.CustomDropDownListItems = new HashSet<CustomDropDownListItems>();
            this.CustomDropDownListTableItems = new HashSet<CustomDropDownListTableItems>();
            this.CustomNumberTableItems = new HashSet<CustomNumberTableItems>();
            this.CustomPercentageTableItems = new HashSet<CustomPercentageTableItems>();
            this.CustomRowTableItems = new HashSet<CustomRowTableItems>();
            this.CustomSumTableItems = new HashSet<CustomSumTableItems>();
            this.CustomTextTableItems = new HashSet<CustomTextTableItems>();
        }
    
        public int Id { get; set; }
        public int CustomTableId { get; set; }
        public int CustomTablePosition { get; set; }
        public string CustomTableItemType { get; set; }
        public string FieldName { get; set; }
        public string DescriptionText { get; set; }
        public string PrefixText { get; set; }
        public string SuffixText { get; set; }
        public string ToolTipText { get; set; }
        public bool Mandatory { get; set; }
        public Nullable<int> ValueWidth { get; set; }
        public Nullable<int> ValueHeight { get; set; }
        public string XPath { get; set; }
        public Nullable<int> TabIndex { get; set; }
        public Nullable<int> MaximumRows { get; set; }
        public Nullable<int> MinimumRows { get; set; }
        public string AturaTag { get; set; }
    
        public virtual ICollection<CustomCheckBoxTableItems> CustomCheckBoxTableItems { get; set; }
        public virtual ICollection<CustomCurrencyTableItems> CustomCurrencyTableItems { get; set; }
        public virtual ICollection<CustomDateTableItems> CustomDateTableItems { get; set; }
        public virtual ICollection<CustomDropDownListItems> CustomDropDownListItems { get; set; }
        public virtual ICollection<CustomDropDownListTableItems> CustomDropDownListTableItems { get; set; }
        public virtual ICollection<CustomNumberTableItems> CustomNumberTableItems { get; set; }
        public virtual ICollection<CustomPercentageTableItems> CustomPercentageTableItems { get; set; }
        public virtual ICollection<CustomRowTableItems> CustomRowTableItems { get; set; }
        public virtual ICollection<CustomSumTableItems> CustomSumTableItems { get; set; }
        public virtual CustomTables CustomTables { get; set; }
        public virtual ICollection<CustomTextTableItems> CustomTextTableItems { get; set; }
    }
}
