using SkillsShowcase.Shared.Domain.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class FavoriteMusicians
    {
        [Key]
        public int FavoriteMusiciansId { get; set; }
        public FavoriteMusiciansOptions MusicianName { get; set; }
        public FavoriteMusiciansDeathStatusOptions DeathStatus { get; set; }
        public string? MusiciansBIO { get; set; }
        public DateTime? FirstShow { get; set; }
        public DateTime? LastShow { get; set; }
    }
}
