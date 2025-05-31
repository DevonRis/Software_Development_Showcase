using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class InvestmentRepository(AppDbContext appDbContext)
    {
        //GET INVESTMENT RESULTS FROM CONTEXT
        internal async Task<InvestmentResultsFromApi[]?> GetInvestmentResults(InvestmentResultsRequest request)
        {
            InvestmentResultsFromApi[]? results = await appDbContext.GetInvestmentResults(request);
            return results?.ToArray();
        }
    }
}