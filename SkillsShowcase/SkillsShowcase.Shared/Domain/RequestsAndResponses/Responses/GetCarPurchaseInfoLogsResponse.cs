using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class GetCarPurchaseInfoLogsResponse
    {
        public SoldVsInProcessCarInfoLogsForApiCall[] CarPurchaseInfoLogs { get; set; } = null!;
    }
}
