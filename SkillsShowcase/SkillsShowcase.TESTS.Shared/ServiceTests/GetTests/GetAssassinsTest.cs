using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Models.Enums;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests.GetTests
{
    [TestClass]
    public class GetAssassinsTest
    {
        [TestMethod]
        public async Task CheckGetMethodForAssassins()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            AssassinsRepository assassinsRepository = new(appDbContext);
            AssassinsService assassinsService = new(assassinsRepository);
            AssassinsResponse response = await assassinsService.GetAssassinsFromRepo();
            string assassinFirstName = "Ezio";
            string assassinLastName = "Lorenzo";
            ContinentalAgeRange age = ContinentalAgeRange.Forty;
            Assert.IsTrue(response.Assassins.Any(assassin => assassin.FirstName == assassinFirstName));
            Assert.IsTrue(response.Assassins.Any(assassin => assassin.LastName == assassinLastName));
            Assert.IsTrue(response.Assassins.Any(assassin => assassin.Age == age));
        }
    }
}
