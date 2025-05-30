using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class MarvelVillainsResponse
    {
        public MarvelVillainsForApiCall[] MarvelVillainsConfirmedKills { get; set; } = null!;
    }
}
