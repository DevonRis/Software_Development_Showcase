using SkillsShowcase.Shared.Domain.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class Guitars
    {
        [Key]
        public int GuitarId { get; set; }
        public GuitarOptions GuitarManufacturer { get; set; }
        public string? GuitarModel { get; set; }
        public double? GuitarPrice { get; set; }
        public DateTime? BuildYear { get; set; }
    }
}
