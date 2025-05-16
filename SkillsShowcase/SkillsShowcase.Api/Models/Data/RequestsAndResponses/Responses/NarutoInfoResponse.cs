using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses
{
    public class NarutoInfoResponse
    {
        public NarutoInfoForApiCall[] NarutoInfo { get; set; } = null!;
    }
}
