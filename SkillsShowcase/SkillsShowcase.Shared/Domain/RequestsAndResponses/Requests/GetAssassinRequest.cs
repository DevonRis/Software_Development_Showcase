using SkillsShowcase.Shared.Domain.Models.Enums;
using System;

namespace SkillsShowcase.Shared.Domain.Requests
{
    public class GetAssassinRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ContinentalAgeRange Age { get; set; }
        public string? Height { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? State { get; set; }
        public string? PerferedMartialArt { get; set; }
        public string? PerferedWeapon { get; set; }
    }
}
