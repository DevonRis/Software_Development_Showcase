using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class FirstQuarterRevenueService(FirstQuarterRevenueRepository firstQuarterRevenueRepository)
    {
        public async Task<FirstQuarterRevenueResponse> GetFirstQuarterRevenue()
        {
            var firstQuarterRevenueData = await firstQuarterRevenueRepository.GetFirstQuarterRepositoryRevenue();
            return new FirstQuarterRevenueResponse
            {
                FirstQuarterRevenue = firstQuarterRevenueData
            };
        }
    }
}
