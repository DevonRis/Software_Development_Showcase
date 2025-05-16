using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses
{
    public class AssassinsResponse
    {
        public AssassinsForApiCall[] Assassins { get; set; } = null!;
    }
}
