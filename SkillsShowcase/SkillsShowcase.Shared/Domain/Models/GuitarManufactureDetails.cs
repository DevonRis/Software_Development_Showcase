using System;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class GuitarManufactureDetails
    {
        [Key]
        public int GuitarManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public DateTime? DateEstablished { get; set; }
    }
}
