namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class MarriageRatesByEducationResults
    {
        public string[]? MarriedOrNotMarried { get; set; } = null!;
        public string[]? EducationLevels { get; set; } = null!;
        public int[]? PopulationOfEachGroup { get; set; } = null!;
        public decimal WhiteMarriedCouples { get; set; }
        public decimal BlackMarriedCouples { get; set; }
        public decimal HispanicMarriedCouples { get; set; }
        public decimal AsianMarriedCouples { get; set; }
        public decimal WhitesMarriedHSD { get; set; }
        public decimal BlacksMarriedHSD { get; set; }
        public decimal HispanicsMarriedHSD { get; set; }
        public decimal AsiansMarriedHSD { get; set; }
    }
}