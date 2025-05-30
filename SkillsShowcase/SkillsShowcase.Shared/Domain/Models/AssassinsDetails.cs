using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class AssassinsDetails
    {
        [Key]
        public int AssignableAssassinId { get; set; }
        public string? AssassinName { get; set; }
        public string? MartialArtKnowledge { get; set; }
        public string? WeaponsKnowledge { get; set; }
        public string? DesignatedRegion { get; set; }
    }
}
