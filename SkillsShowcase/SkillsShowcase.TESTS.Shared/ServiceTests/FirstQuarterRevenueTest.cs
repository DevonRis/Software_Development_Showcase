using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.TESTS.Shared.ServiceTests
{
    [TestClass]
    public class FirstQuarterRevenueTest
    {
        [TestMethod]
        public async Task GetFirstQuarterRevenue()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            FirstQuarterRevenueRepository firstQuarterRevenueRepository = new(appDbContext);
            FirstQuarterRevenueService firstQuarterRevenueService = new(firstQuarterRevenueRepository);
            FirstQuarterRevenueResponse response = await firstQuarterRevenueService.GetFirstQuarterRevenue();
            var januaryRevenue = response.FirstQuarterRevenue
                .Where(revenue => revenue.Month == FirstQuarterRevenueOptions.January)
                .FirstOrDefault();
            int januaryRevenueAmount = januaryRevenue.MonthRevenue;
            Assert.AreEqual(FirstQuarterRevenueOptions.January, januaryRevenue.Month);
            Assert.AreEqual(4015, januaryRevenueAmount);
        }
    }
}
