using SkillsShowcase.Api.Models.GuitarService;
using SkillsShowcase.Shared.Domain.Repositories;

namespace SkillsShowcase.Shared.Domain.Services
{
    public class GuitarService(GuitarRepository guitarRepository)
    {
        public GetGuitarsResponse GetGuitars()
        {
            return guitarRepository.GetGuitars();
        }
    }
}
