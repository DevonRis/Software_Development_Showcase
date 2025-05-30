using System;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class GuitarManufactureDetailsForApiCall
    {
        public int GuitarManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public DateTime? DateEstablished { get; set; }
    }
}
