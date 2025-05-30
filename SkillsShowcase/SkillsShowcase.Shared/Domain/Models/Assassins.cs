using SkillsShowcase.Shared.Domain.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class Assassins
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
