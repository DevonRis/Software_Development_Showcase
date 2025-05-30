using SkillsShowcase.Shared.Domain.Models.Enums;
using System;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class AssassinsForApiCall
    {
        public int AssassinId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ContinentalAgeRange Age { get; set; }
        public string? Height { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public AllFiftyStates State { get; set; }
        public MartialArts MartialArt { get; set; }
        public Weapons Weapon { get; set; }
    }
}
