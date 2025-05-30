using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class AssassinsResponse
    {
        public AssassinsForApiCall[] Assassins { get; set; } = null!;
    }
}
