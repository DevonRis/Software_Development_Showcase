using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses
{
    public class MarvelVillainsResponse
    {
        public MarvelVillainsForApiCall[] MarvelVillainsConfirmedKills { get; set; } = null!;
    }
}
