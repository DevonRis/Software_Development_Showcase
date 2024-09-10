using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class SoldVsInProcessCarInfoLogs
    {
        public CarModels CarModel { get; set; }
        public int SoldCars { get; set; }
        public int InProcessCars { get; set; }
    }
}
