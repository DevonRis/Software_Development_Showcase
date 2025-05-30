using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class GetGuitarMfDetailsResponse
    {
        public GuitarManufactureDetailsForApiCall[] GuitarMfDetails { get; set; } = null!;
    }
}
