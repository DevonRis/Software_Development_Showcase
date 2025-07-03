using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;
using SkillsShowcase.Shared.Domain.Models.Enums;
using SkillsShowcase.Shared.Domain.Models.MethodExtensions;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class EducationDataService(GetEducationDataFromRepository getEducationDataFromRepo)
    {
        public async Task<EducationDataResponse> GetEducationInfoFromRepo(EducationDataRequest request)
        {
            EducationDataFromApi[]? educationData = await getEducationDataFromRepo.GetEducationData(request);

            string[] raceDemographicsDescriptions = new string[]
            {
                RaceDemographics.Whites.GetEnumDescription(),
                RaceDemographics.Asians.GetEnumDescription(),
                RaceDemographics.AfricanAmericans.GetEnumDescription(),
                RaceDemographics.Hispanics.GetEnumDescription(),
                RaceDemographics.BlackMen.GetEnumDescription(),
                RaceDemographics.BlackWomen.GetEnumDescription()
            };

            EducationDataResponse response = new EducationDataResponse() 
            {
                EducationResultsData = educationData,
                RaceDemographics = raceDemographicsDescriptions
            };

            return response;
        }
    }
}