using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses
{
    public class GetCarPurchaseInfoLogsResponse
    {
        public SoldVsInProcessCarInfoLogs[] CarPurchaseInfoLogs { get; set; } = null!;
    }
}
