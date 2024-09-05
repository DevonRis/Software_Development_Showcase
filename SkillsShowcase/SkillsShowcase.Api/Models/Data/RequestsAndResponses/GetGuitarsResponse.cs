using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses
{
    public class GetGuitarsResponse
    {
        public IEnumerable<Guitars> Guitars { get; set; } = null!;
    }
}
