using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class MarvelVillainsForApiCall
    {
        public MarvelVillainsOptions VillainName { get; set; }
        public int? VillainConfirmedKills { get; set; }
    }
}
