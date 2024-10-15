using SkillsShowcase.Shared.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class NarutoCharacterDetails
    {
        [Key]
        public int NarutoCharacterId { get; set; }
        public NarutoCharacterStatus Status { get; set; }
        public string? CharacterBio { get; set; }
        public int KillCount { get; set; }
    }
}
