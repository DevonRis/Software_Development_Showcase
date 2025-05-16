namespace SkillsShowcase.Shared.Domain.Models
{
    using System;
    public partial class SearchRatesWithEFLDetails_Result
    {
        public int RateId { get; set; }
        public int RateTypeId { get; set; }
        public string RateTypeName { get; set; }
        public string TDSPName { get; set; }
        public string REPName { get; set; }
        public string Product { get; set; }
        public Nullable<int> Term { get; set; }
        public Nullable<decimal> EnergyCharge { get; set; }
        public decimal kwh500 { get; set; }
        public decimal kwh1000 { get; set; }
        public decimal kwh2000 { get; set; }
        public Nullable<decimal> EFLMatch { get; set; }
        public Nullable<decimal> Renewable { get; set; }
        public System.DateTime ActiveTime { get; set; }
        public System.DateTime InactiveTime { get; set; }
        public Nullable<System.DateTime> ApprovalTime { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string EFLUrl { get; set; }
    }
}
