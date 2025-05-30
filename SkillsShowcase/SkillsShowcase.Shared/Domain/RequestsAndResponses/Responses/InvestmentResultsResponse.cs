using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class InvestmentResultsResponse
    {
        public InvestmentResultsFromApi[] FinancialInvestmentResults { get; set; } = null!;
    }
}
