using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests
{
    public class MarriageByEducationRequest
    {
        public MarriageRatesByEducationResults[]? MarriageData { get; set; } = null!;
    }
}
