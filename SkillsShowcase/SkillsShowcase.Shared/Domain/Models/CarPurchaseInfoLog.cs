using SkillsShowcase.Shared.Domain.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class CarPurchaseInfoLog
    {
        [Key]
        public int CarPurchaseInfoLogId { get; set; }
        public CarModels CarModel { get; set; }
        public CarPurchaseEventTypeOption CarPurchaseStatus { get; set; }
        public DateTime CarArrivalInDealership { get; set; }
        public DateTime CarPurchaseDate { get; set; }
        public int CarModelPrice { get; set; }
        public int CarModelQuantityLeft { get; set; }
        public string CustomerName { get; set; } = null!;
        public CarPurchaseEventTypeOption CustomerCreditStatus { get; set; }
    }
}
