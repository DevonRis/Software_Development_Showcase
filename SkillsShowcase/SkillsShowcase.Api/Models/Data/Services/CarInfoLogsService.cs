using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class CarInfoLogsService(CarInfoLogsRepository carInfoLogsRepository)
    {
        public async Task<GetCarPurchaseInfoLogsResponse> GetSoldVsInProcessCarInfoLogs()
        {
            var soldVsInprogressData = await carInfoLogsRepository.GetSoldVsInProcessCarRepositoryInfoLogs();
            return new GetCarPurchaseInfoLogsResponse
            {
                CarPurchaseInfoLogs = soldVsInprogressData
            };
        }
    }
}