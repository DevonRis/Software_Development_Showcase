using SkillsShowcase.Shared.Domain.Models.Enums;
using System;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class FavoriteMusiciansForApiCall
    {
        public FavoriteMusiciansOptions MusicianName { get; set; }
        public FavoriteMusiciansDeathStatusOptions DeathStatus { get; set; }
        public string MusiciansBIO { get; set; }
        public DateTime? FirstShow { get; set; }
        public DateTime? LastShow { get; set; }
    }
}
