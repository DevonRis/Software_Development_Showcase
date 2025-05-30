using SkillsShowcase.Shared.Domain.Models;
using System.Collections.Generic;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class GetGuitarsResponse
    {
        public IEnumerable<Guitars> Guitars { get; set; } = null!;
    }
}
