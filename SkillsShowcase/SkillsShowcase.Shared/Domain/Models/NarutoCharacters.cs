using SkillsShowcase.Shared.Domain.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class NarutoCharacters
    {
        [Key]
        public int NarutoCharacterId { get; set; }
        public string? CharacterName { get; set; }
        public string? ClanBloodline { get; set; }
        public int Age { get; set; }
        public NarutoVillages Village { get; set; }
        public virtual ICollection<NarutoCharacterDetails> NarutoCharacterDetails { get; set; } = [];
    }
}
