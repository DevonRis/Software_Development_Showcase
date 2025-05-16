using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses
{
    public class GetGuitarMfDetailsResponse
    {
        public GuitarManufactureDetailsForApiCall[] GuitarMfDetails { get; set; } = null!;
    }
}
