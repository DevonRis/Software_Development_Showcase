using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class SoldVsInProcessCarInfoLogsForApiCall
    {
        public CarModels CarModel { get; set; }
        public int SoldCars { get; set; }
        public int InProcessCars { get; set; }
    }
}