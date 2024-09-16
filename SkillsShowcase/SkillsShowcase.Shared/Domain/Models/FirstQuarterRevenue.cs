using SkillsShowcase.Shared.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class FirstQuarterRevenue
    {
        [Key]
        public int FirstQuarterRevenueId { get; set; }
        public int MonthRevenue { get; set; }
        public FirstQuarterRevenueOptions Month { get; set; }
    }
}
