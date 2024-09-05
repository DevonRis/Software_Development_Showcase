using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.GuitarService;

namespace SkillsShowcase.Shared.Domain.Repositories
{
    public class GuitarRepository(AppDbContext appDbContext)
    {
        public GetGuitarsResponse GetGuitars()
        {
            GetGuitarsResponse response = new()
            {
                Guitars = appDbContext.Guitars
            };
            return response;
        }
    }
}
