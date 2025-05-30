using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests
{
    [TestClass]
    public class GuitarServiceTest
    {
        [TestMethod]
        public void GetGuitarsData()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            GuitarRepository guitarRepository = new(appDbContext);
            GuitarService guitarService = new(guitarRepository);
            GetGuitarsResponse response = guitarService.GetGuitars();
            var stratocaster = response.Guitars
                .Where(guitar => guitar.GuitarModel == "Custom Shop American Stratocaster")
                .FirstOrDefault();
            Assert.AreEqual("Custom Shop American Stratocaster", stratocaster.GuitarModel);
        }
    }
}
