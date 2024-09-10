using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.TESTS.Shared.ServiceTests
{
    [TestClass]
    public class CarsPurchasedVsInProcessTest
    {
        [TestMethod]
        public async Task GetSoldVsInProcessCarInfoLogs()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=SkillsShowcase;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString).Options;
            AppDbContext appDbContext = new(options);
            CarInfoLogsRepository carInfoLogsRepository = new(appDbContext);
            CarInfoLogsService carInfoLogsService = new(carInfoLogsRepository);
            GetCarPurchaseInfoLogsResponse response = await carInfoLogsService.GetSoldVsInProcessCarInfoLogs();
            var carModel = response.CarPurchaseInfoLogs
                .Where(car => car.CarModel == CarModels.InfinityQ60)
                .FirstOrDefault();
            var soldCar = response.CarPurchaseInfoLogs
                .Where(car => car.SoldCars == 1)
                .FirstOrDefault();
            var inProcessCar = response.CarPurchaseInfoLogs
                .Where(car => car.InProcessCars == 0)
                .FirstOrDefault();
            Assert.AreEqual(CarModels.InfinityQ60, carModel.CarModel);
            Assert.AreEqual(1, soldCar.SoldCars);
            Assert.AreEqual(0, inProcessCar!.InProcessCars);
        }
    }
}
