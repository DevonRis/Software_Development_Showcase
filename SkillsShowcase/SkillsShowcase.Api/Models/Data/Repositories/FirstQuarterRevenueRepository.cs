using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class FirstQuarterRevenueRepository(AppDbContext appDbContext)
    {
        internal async Task<FirstQuarterRevenueForApiCall[]> GetFirstQuarterRepositoryRevenue()
        {
            var firstQuarterRevenueData = await appDbContext.FirstQuarterRevenue
                .GroupBy(data => data.Month)
                .Select(data => new FirstQuarterRevenueForApiCall 
                {
                    Month = data.Key,
                    MonthRevenue = data.Sum(data => data.MonthRevenue)
                }).ToArrayAsync();
            return firstQuarterRevenueData;
        }
    }
}
