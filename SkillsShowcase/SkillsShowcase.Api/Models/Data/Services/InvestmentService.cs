using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class InvestmentService(InvestmentRepository investmentRepository)
    {
        public async Task<InvestmentResultsResponse> ResultsFromRepo(InvestmentResultsRequest request)
        {
            InvestmentResultsFromApi[]? investmentData = await investmentRepository.GetInvestmentResults(request);
            return new InvestmentResultsResponse
            {
                FinancialInvestmentResults = investmentData
            };
        }
    }
}
