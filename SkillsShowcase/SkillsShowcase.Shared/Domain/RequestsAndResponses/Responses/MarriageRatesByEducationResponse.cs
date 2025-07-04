using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class MarriageRatesByEducationResponse
    {
        public string[]? Ethnicities { get; set; }
        public MarriageRatesByEducationResults[]? MarriageRatesResults { get; set; } = null!;
    }
}