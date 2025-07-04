using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests.GetTests
{
    [TestClass]
    public class GetMarriageRatesByEducationTest
    {
        [TestMethod]
        public async Task CheckForMarriageRatesByEducation()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            GetEducationDataFromRepository getEducationDataFromRepo = new(appDbContext);
            MarriageByEducationRequest request = new();
            EducationDataService educationDataService = new(getEducationDataFromRepo);
            MarriageRatesByEducationResponse? response = await educationDataService.GetMarriageRatesDataFromRepo(request);
            Assert.IsNotNull(response, "Response should not be null.");
            Assert.IsNotNull(response.MarriageRatesResults, "MarriageRatesResults should not be null.");
            Assert.IsTrue(response.MarriageRatesResults.Length > 0, "MarriageRatesResults should contain results.");
        }
    }
}
