using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Models.Enums;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.TESTS.Shared.ServiceTests
{
    [TestClass]
    public class MarvelVillainsTest
    {
        [TestMethod]
        public async Task GetMarvelVillainsKills()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            MarvelVillainsRepository marvelVillainsRepository = new(appDbContext);
            MarvelVillainsService marvelVillainsService = new(marvelVillainsRepository);
            MarvelVillainsResponse response = await marvelVillainsService.GetMarvelVillainsConfirmedKills();
            var doctorDoom = response.MarvelVillainsConfirmedKills
                .Where(villain => villain.VillainName == MarvelVillainsOptions.DoctorDoom).FirstOrDefault();
            var doctorDoomKills = response.MarvelVillainsConfirmedKills
                .Where(villain => villain.VillainConfirmedKills == 1053).FirstOrDefault();
            Assert.AreEqual(MarvelVillainsOptions.DoctorDoom, doctorDoom.VillainName);
            Assert.AreEqual(1053, doctorDoomKills.VillainConfirmedKills);
        }
    }
}
