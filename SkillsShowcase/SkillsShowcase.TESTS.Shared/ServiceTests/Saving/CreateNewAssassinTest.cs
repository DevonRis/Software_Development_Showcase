using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Save;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.TESTS.Shared.ServiceTests.Saving
{
    [TestClass]
    public class CreateNewAssassinTest
    {
        [TestMethod]
        public async Task CheckCreatingNewAssassin()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            AssassinsRepository assassinsRepository = new(appDbContext);
            AssassinsService assassinsService = new(assassinsRepository);
            string firstName = "Devon";
            string lastName = "Rismay";
            ContinentalAgeRange age = ContinentalAgeRange.TwentyNine;
            string height = "5'8";
            DateTime registeredDate = new DateTime(2025, 2, 22, 1, 20, 11);
            AllFiftyStates state = AllFiftyStates.TX;
            MartialArts martialArt = MartialArts.Boxing;
            Weapons weapon = Weapons.Remington700;

            //New object for the request
            AssassinsPostRequest assassinsPostRequest = new()
            {
                CreateAssassins = new()
                {
                    AssassinId = 2,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Height = height,
                    RegisteredDate = registeredDate,
                    State = state,
                    MartialArt = martialArt,
                    Weapon = weapon,
                }
            };
            var existingAssassin = await appDbContext.Assassins
                .FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName);
            Assert.IsNotNull(existingAssassin, "Assassin does not exist in the database.");
        }
    }
}
