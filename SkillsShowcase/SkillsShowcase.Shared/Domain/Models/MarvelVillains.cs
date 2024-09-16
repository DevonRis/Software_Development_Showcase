using SkillsShowcase.Shared.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class MarvelVillains
    {
        [Key]
        public int MarvelVillanId { get; set; }
        public MarvelVillainsOptions VillainName { get; set; }
        public int? VillainConfirmedKills { get; set; }
    }
}
