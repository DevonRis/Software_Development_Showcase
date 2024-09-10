using SkillsShowcase.Shared.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class CarPurchaseEventTypes
    {
        [Key]
        public CarPurchaseEventTypeOption CarPurchaseEventTypeId { get; set; }
        public string CarPurchaseEventTypeName { get; set; } = null!;
        public string CarPurchaseEventTypeDescription { get; set; } = null!;
    }
}