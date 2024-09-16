using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class MarvelVillainsRepository(AppDbContext appDbContext)
    {
        internal async Task<MarvelVillainsForApiCall[]> GetMarvelVillainsRepositoryConfirmedKills()
        {
            var marvelVillainsData = await appDbContext.MarvelVillains
                .GroupBy(data => data.VillainName)
                .Select(data => new MarvelVillainsForApiCall
                {
                    VillainName = data.Key,
                    VillainConfirmedKills = data.Sum(data => data.VillainConfirmedKills)
                }).ToArrayAsync();
            return marvelVillainsData;
        }
    }
}
