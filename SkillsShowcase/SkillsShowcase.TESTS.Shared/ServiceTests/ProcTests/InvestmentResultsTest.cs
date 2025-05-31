using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests.ProcTests
{
    [TestClass]
    public class InvestmentResultsTest
    {
        [TestMethod]
        public async Task CheckInvestmentResults()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            InvestmentRepository investmentRepository = new(appDbContext);
            InvestmentService investmentService = new(investmentRepository);
            InvestmentResultsRequest request = new InvestmentResultsRequest() 
            {
                CurrentAge = 30,
                RetirementAge = 65,
                Salary = 60000,
                SalaryGrowthRate = 3,
                InitialInvestment = 10000,
                MonthlyContribution = 500,
                AnnualReturn = 7,
                MonthlyLivingExpenses = 2000,
                GoalAmount = 1000000
            };
            InvestmentResultsResponse? response = investmentService.ResultsFromRepo(request)
                .GetAwaiter()
                .GetResult();
            if (response == null) 
            {
                Assert.Fail("InvestmentResultsResponse is null. Check the database connection and data.");
            }
            else 
            { 
                Assert.IsNotNull(response);
            }
        }
    }
}