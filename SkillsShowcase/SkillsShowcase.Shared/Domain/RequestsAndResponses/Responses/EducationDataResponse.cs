using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses
{
    public class EducationDataResponse
    {
        public string[]? RaceDemographics { get; set; }
        public EducationDataFromApi[]? EducationResultsData { get; set; } = null!;
    }
}
