using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests.GetTests
{
    [TestClass]
    public class GetUpperMiddleClassDataTest
    {
        [TestMethod]
        public async Task CheckForUpperMiddleClassData()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            GetEducationDataFromRepository getEducationDataFromRepo = new(appDbContext);
            UpperMiddleClassRequest request = new();
            EducationDataService educationDataService = new(getEducationDataFromRepo);
            UpperMiddleClassResponse? response = await educationDataService.GetUpperMiddleClassDataFromRepo(request);
            Assert.IsNotNull(response, "Response should not be null.");
            Assert.IsNotNull(response.IncomeRange, "Income Range should not be null.");
            Assert.IsTrue(response.UpperMiddleClass?.Length > 0, "UpperMiddleClassResults should contain results.");
        }
    }
}
