using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class NarutoInfoResponse
    {
        public NarutoInfoForApiCall[] NarutoInfo { get; set; } = null!;
    }
}
