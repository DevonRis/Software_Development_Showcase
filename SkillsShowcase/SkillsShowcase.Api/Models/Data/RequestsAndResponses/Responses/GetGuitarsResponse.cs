using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses
{
    public class GetGuitarsResponse
    {
        public IEnumerable<Guitars> Guitars { get; set; } = null!;
    }
}
