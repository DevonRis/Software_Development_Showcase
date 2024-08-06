using SkillsShowcase.Shared.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class DcVillains
    {
        [Key]
        public int DcVillanId { get; set; }
        public string? VillanName { get; set; }
        public string? VillanPower { get; set; }
        public int? VillanAge { get; set; }
        public string? Weaknesses { get; set; }
        public string? CityLocation { get; set; }
        public ThreatLevel? ThreatLevel { get; set; }
        public ArkhamAsylum? PlacedInArkham { get; set; }
        public CallSupermanForVillains? SupermanLevelVillan { get; set; }
    }
}
