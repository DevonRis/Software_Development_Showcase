using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests
{
    [TestClass]
    public class NarutoInfoTest
    {
        [TestMethod]
        public async Task CheckNarutoInfo()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            NarutoInfoRepository narutoInfoRepository = new(appDbContext);
            NarutoInfoService narutoInfoService = new(narutoInfoRepository);
            NarutoInfoResponse response = await narutoInfoService.GetNarutoInfo();
            int kuramaKills = 5000;
            string narutoUzumaki = "Naruto Uzumaki";
            Assert.IsTrue(response.NarutoInfo.Any(character => character.NarutoCharacterDetails.Any(k => k.KillCount == kuramaKills)));
            Assert.IsTrue(response.NarutoInfo.Any(character => character.CharacterName == narutoUzumaki));
        }
    }
}
