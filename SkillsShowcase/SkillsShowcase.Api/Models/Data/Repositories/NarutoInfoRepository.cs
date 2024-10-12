using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class NarutoInfoRepository(AppDbContext appDbContext)
    {
        internal async Task<NarutoInfoForApiCall[]> GetNarutInfoForRepository() 
        {
            var result = await appDbContext.NarutoCharacters.Include(e => e.NarutoCharacterDetails).ToArrayAsync();
            return result.Select(character => new NarutoInfoForApiCall
            {
                NarutoCharacterId = character.NarutoCharacterId,
                CharacterName = character.CharacterName,
                ClanBloodline = character.ClanBloodline,
                Age = character.Age,
                Village = character.Village,
                NarutoCharacterDetails = character.NarutoCharacterDetails
            }).ToArray(); ;
        }
    }
}
