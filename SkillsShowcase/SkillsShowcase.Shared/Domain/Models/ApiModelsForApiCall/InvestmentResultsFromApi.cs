namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class InvestmentResultsFromApi
    {
        public decimal FutureValue { get; set; }
        public decimal TotalContributions { get; set; }
        public decimal TotalInterestEarned { get; set; }
        public bool GoalMet { get; set; }
        public decimal ProjectedAnnualIncome { get; set; }
        public int RetirementAge { get; set; }
        public int YearsToInvest { get; set; }
    }
}
