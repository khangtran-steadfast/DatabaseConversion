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
    
    public partial class Landlord
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Roof { get; set; }
        public Nullable<int> YearBuilt { get; set; }
        public string BuildingType { get; set; }
        public string HolidayHouse { get; set; }
        public string Construction { get; set; }
        public string DoorSecurity { get; set; }
        public string BuildingConstruction { get; set; }
        public string Floors { get; set; }
        public string BuildingSize { get; set; }
        public string HowOccupied { get; set; }
        public string WindowSecurity { get; set; }
        public string Alarm { get; set; }
        public string FurtherDetails { get; set; }
        public string Security { get; set; }
        public Nullable<bool> UnoccupiedMoreThan60Days { get; set; }
        public Nullable<bool> HeritageListed { get; set; }
        public string PreviousInsurer { get; set; }
        public Nullable<decimal> SumInsuredBuilding { get; set; }
        public Nullable<decimal> SumInsuredUnspecifiedContents { get; set; }
        public Nullable<decimal> PubLiability { get; set; }
        public Nullable<decimal> WeeklyRent { get; set; }
        public Nullable<decimal> LossOfRent { get; set; }
        public Nullable<decimal> RentDefault { get; set; }
        public Nullable<bool> StrataLossOfRent { get; set; }
        public Nullable<decimal> StrataLossOfRentAmount { get; set; }
        public Nullable<decimal> LegalExpenses { get; set; }
        public string Excess { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> PremiumId { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public string OccupancyType { get; set; }
        public string Endorsements { get; set; }
        public Nullable<bool> ConvertedToNewFormat { get; set; }
        public Nullable<bool> IsInNeedOfRepair { get; set; }
        public Nullable<bool> IsUsedForBusiness { get; set; }
        public string HomeType { get; set; }
        public string AlarmType { get; set; }
    }
}
