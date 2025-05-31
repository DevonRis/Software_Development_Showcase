namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests
{
    public class InvestmentResultsRequest
    {
        public int CurrentAge { get; set; }
        public int RetirementAge { get; set; }
        public int Salary { get; set; }
        public decimal SalaryGrowthRate { get; set; }
        public decimal InitialInvestment { get; set; }
        public decimal MonthlyContribution { get; set; }
        public decimal AnnualReturn { get; set; }
        public decimal MonthlyLivingExpenses { get; set; }
        public decimal GoalAmount { get; set; }
    }
}
