using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses
{
    public class FirstQuarterRevenueResponse
    {
        public FirstQuarterRevenueForApiCall[] FirstQuarterRevenue { get; set; } = null!;
    }
}
