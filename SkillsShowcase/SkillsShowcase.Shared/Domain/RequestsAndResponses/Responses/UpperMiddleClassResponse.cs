using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class UpperMiddleClassResponse
    {
        public string? IncomeRange { get; set; }
        public TheUpperMiddleClassResults[]? UpperMiddleClass { get; set; } = null!;
    }
}
