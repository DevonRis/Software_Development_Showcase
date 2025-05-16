using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Requests;
using SkillsShowcase.Shared.Domain.Models.Enums;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.TESTS.Shared.ServiceTests
{
    [TestClass]
    public class GetAssassinFromProcTest
    {
        [TestMethod]
        public async Task CheckGetAssassinFromProc() 
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

            GetAssassinRequest request = new() 
            { 
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Height = height,
                RegisterDate = registeredDate,
                State = state,
                PerferedMartialArt = martialArt,
                PerferedWeapon = weapon
            };
            var response = assassinsService.GetAssignedAssassin(request).GetAwaiter().GetResult();

            AssignedAssassinForApiCall[]? assignedAssassinData = response.AssignedAssassin;

            int stop = 0;
        }
    }
}
