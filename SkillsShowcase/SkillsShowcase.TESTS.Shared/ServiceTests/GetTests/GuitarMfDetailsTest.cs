using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests.GetTests
{
    [TestClass]
    public class GuitarMfDetailsTest
    {
        [TestMethod]
        public async Task CheckGuitarMfDetails()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            GuitarMfRepository guitarMfDetailsRepository = new(appDbContext);
            GuitarMfDetailsService guitarMfDetailsService = new(guitarMfDetailsRepository);
            GetGuitarMfDetailsResponse response = await guitarMfDetailsService.GetGuitarMf();
            string guitarMfName = "Fender";
            string website = "www.prsguitars.com";
            Assert.IsTrue(response.GuitarMfDetails.Any(guitar => guitar.ManufacturerName == guitarMfName));
            Assert.IsTrue(response.GuitarMfDetails.Any(guitar => guitar.Website == website));
        }
    }
}
