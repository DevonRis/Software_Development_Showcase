using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class FirstQuarterRevenueForApiCall
    {
        public FirstQuarterRevenueOptions Month { get; set; }
        public int MonthRevenue { get; set; }
    }
}
