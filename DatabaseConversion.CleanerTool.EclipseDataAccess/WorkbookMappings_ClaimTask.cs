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
    
    public partial class WorkbookMappings_ClaimTask
    {
        public int ctworma_id { get; set; }
        public string ctworma_name { get; set; }
        public int ctworma_wor_format { get; set; }
        public Nullable<int> ctworma_branch { get; set; }
        public Nullable<int> ctworma_brokerRep { get; set; }
        public Nullable<int> ctworma_classOfBusiness { get; set; }
        public Nullable<int> ctworma_insurer { get; set; }
        public Nullable<int> ctworma_claimTaskType { get; set; }
    
        public virtual branches branches { get; set; }
        public virtual claim_task_types claim_task_types { get; set; }
        public virtual CustomWorkbooks CustomWorkbooks { get; set; }
        public virtual entities entities { get; set; }
        public virtual entities entities1 { get; set; }
        public virtual gen_ins_classes_of_business gen_ins_classes_of_business { get; set; }
    }
}
