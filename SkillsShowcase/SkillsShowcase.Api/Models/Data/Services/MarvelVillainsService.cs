using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class MarvelVillainsService(MarvelVillainsRepository marvelVillainsRepository)
    {
        public async Task<MarvelVillainsResponse> GetMarvelVillainsConfirmedKills()
        {
            var marvelVillainsData = await marvelVillainsRepository.GetMarvelVillainsRepositoryConfirmedKills();
            return new MarvelVillainsResponse
            {
                MarvelVillainsConfirmedKills = marvelVillainsData
            };
        }
    }
}
