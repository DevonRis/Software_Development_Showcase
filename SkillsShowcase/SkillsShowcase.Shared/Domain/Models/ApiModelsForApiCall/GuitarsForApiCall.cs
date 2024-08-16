using SkillsShowcase.Shared.Domain.Models.Enums;
using System;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class GuitarsForApiCall
    {
        public int GuitarId { get; set; }
        public GuitarOptions GuitarManufacturer { get; set; }
        public string? GuitarModel { get; set; }
        public double? GuitarPrice { get; set; }
        public DateTime? BuildYear { get; set; }
    }
}
