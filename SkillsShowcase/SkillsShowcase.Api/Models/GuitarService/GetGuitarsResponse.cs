using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.GuitarService
{
    public class GetGuitarsResponse
    {
        public IEnumerable<Guitars> Guitars { get; set; } = null!;
    }
}

