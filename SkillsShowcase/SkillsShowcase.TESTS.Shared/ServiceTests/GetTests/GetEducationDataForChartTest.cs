using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests.GetTests
{
    [TestClass]
    public class GetEducationDataForChartTest
    {
        [TestMethod]
        public async Task CheckForEducationDataResults()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            GetEducationDataFromRepository getEducationDataFromRepo = new(appDbContext);
            EducationDataRequest request = new();
            //Last part below


            EducationDataService educationDataService = new(getEducationDataFromRepo);
            EducationDataResponse? response = await educationDataService.GetEducationInfoFromRepo(request);
            Assert.IsNotNull(response, "Response should not be null.");
            Assert.IsNotNull(response.EducationResultsData, "EducationResultsData should not be null.");
            Assert.IsTrue(response.EducationResultsData.Length > 0, "EducationResultsData should contain results.");
        }
    }
}
