using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses
{
    public class GetCarPurchaseInfoLogsResponse
    {
        public SoldVsInProcessCarInfoLogsForApiCall[] CarPurchaseInfoLogs { get; set; } = null!;
    }
}
