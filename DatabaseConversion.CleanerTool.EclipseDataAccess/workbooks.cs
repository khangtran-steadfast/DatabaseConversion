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
    
    public partial class workbooks
    {
        public workbooks()
        {
            this.atura_tagvalue = new HashSet<atura_tagvalue>();
            this.FarmInterruption = new HashSet<FarmInterruption>();
            this.FarmLiability = new HashSet<FarmLiability>();
            this.GeneralProperty = new HashSet<GeneralProperty>();
            this.HomePolicy = new HashSet<HomePolicy>();
            this.ICloseWorkbookHeader = new HashSet<ICloseWorkbookHeader>();
            this.journals = new HashSet<journals>();
            this.LandTransit = new HashSet<LandTransit>();
            this.MachineryBreakdown = new HashSet<MachineryBreakdown>();
            this.Motor = new HashSet<Motor>();
            this.PersonalAccident = new HashSet<PersonalAccident>();
            this.policies = new HashSet<policies>();
            this.Premiums = new HashSet<Premiums>();
            this.sunrise_instalment = new HashSet<sunrise_instalment>();
            this.sunrise_workbooks = new HashSet<sunrise_workbooks>();
            this.TT_RiskSection = new HashSet<TT_RiskSection>();
            this.TT_RiskSectionDetail = new HashSet<TT_RiskSectionDetail>();
            this.VehicleMachinery = new HashSet<VehicleMachinery>();
            this.Workbook_Notes = new HashSet<Workbook_Notes>();
            this.Workbook_Perticulars = new HashSet<Workbook_Perticulars>();
            this.Workbook_SOA = new HashSet<Workbook_SOA>();
        }
    
        public int wor_id { get; set; }
        public int wor_parent_id { get; set; }
        public string wor_created_who { get; set; }
        public System.DateTime wor_created_when { get; set; }
        public string wor_updated_who { get; set; }
        public Nullable<System.DateTime> wor_updated_when { get; set; }
        public Nullable<int> wor_duration { get; set; }
        public bool wor_closed { get; set; }
        public string wor_contact { get; set; }
        public Nullable<int> wor_source_of_business { get; set; }
        public Nullable<int> wor_transaction_type { get; set; }
        public Nullable<int> wor_workbook { get; set; }
        public string wor_notes { get; set; }
        public Nullable<System.DateTime> wor_followup_date { get; set; }
        public Nullable<int> wor_time_spent { get; set; }
        public string wor_ent_name { get; set; }
        public Nullable<int> wor_buscatty_id { get; set; }
        public Nullable<int> wor_existing_version { get; set; }
        public Nullable<bool> wor_is_hidden { get; set; }
        public Nullable<decimal> wor_pol_total_gross_premium { get; set; }
        public Nullable<decimal> wor_terrorism_levy { get; set; }
        public string wor_invoice_comments { get; set; }
        public bool wor_DetailsCopied { get; set; }
        public bool wor_elite_workbook { get; set; }
        public Nullable<bool> Transmitted { get; set; }
        public Nullable<bool> Reversed { get; set; }
    
        public virtual ICollection<atura_tagvalue> atura_tagvalue { get; set; }
        public virtual business_category_types business_category_types { get; set; }
        public virtual ICollection<FarmInterruption> FarmInterruption { get; set; }
        public virtual ICollection<FarmLiability> FarmLiability { get; set; }
        public virtual gen_ins_transaction_types gen_ins_transaction_types { get; set; }
        public virtual general_insurance general_insurance { get; set; }
        public virtual general_insurance_workbooks general_insurance_workbooks { get; set; }
        public virtual ICollection<GeneralProperty> GeneralProperty { get; set; }
        public virtual ICollection<HomePolicy> HomePolicy { get; set; }
        public virtual ICollection<ICloseWorkbookHeader> ICloseWorkbookHeader { get; set; }
        public virtual ICollection<journals> journals { get; set; }
        public virtual ICollection<LandTransit> LandTransit { get; set; }
        public virtual ICollection<MachineryBreakdown> MachineryBreakdown { get; set; }
        public virtual ICollection<Motor> Motor { get; set; }
        public virtual ICollection<PersonalAccident> PersonalAccident { get; set; }
        public virtual ICollection<policies> policies { get; set; }
        public virtual ICollection<Premiums> Premiums { get; set; }
        public virtual sources_of_business sources_of_business { get; set; }
        public virtual ICollection<sunrise_instalment> sunrise_instalment { get; set; }
        public virtual ICollection<sunrise_workbooks> sunrise_workbooks { get; set; }
        public virtual TIMWorkbookHeader TIMWorkbookHeader { get; set; }
        public virtual ICollection<TT_RiskSection> TT_RiskSection { get; set; }
        public virtual ICollection<TT_RiskSectionDetail> TT_RiskSectionDetail { get; set; }
        public virtual ICollection<VehicleMachinery> VehicleMachinery { get; set; }
        public virtual ICollection<Workbook_Notes> Workbook_Notes { get; set; }
        public virtual ICollection<Workbook_Perticulars> Workbook_Perticulars { get; set; }
        public virtual ICollection<Workbook_SOA> Workbook_SOA { get; set; }
        public virtual WorkbookHeader WorkbookHeader { get; set; }
    }
}
