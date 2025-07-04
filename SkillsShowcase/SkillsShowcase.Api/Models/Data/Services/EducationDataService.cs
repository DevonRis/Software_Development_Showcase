using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;
using SkillsShowcase.Shared.Domain.Models.Enums;
using SkillsShowcase.Shared.Domain.Models.MethodExtensions;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class EducationDataService(GetEducationDataFromRepository repo)
    {
        public async Task<EducationDataResponse> GetEducationInfoFromRepo(EducationDataRequest request)
        {
            EducationDataFromApi[]? educationData = await repo.GetEducationData(request);

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
        public async Task<MarriageRatesByEducationResponse> GetMarriageRatesDataFromRepo(MarriageByEducationRequest request) 
        {
            var (resultsFromRepo, populationOfEachGroup) = await repo.GetMarriageDataFromRepository(request, new int[] { });

            string[] ethnicities = new string[]
            {
                RaceDemographics.Whites.GetEnumDescription(),
                RaceDemographics.Asians.GetEnumDescription(),
                RaceDemographics.AfricanAmericans.GetEnumDescription(),
                RaceDemographics.Hispanics.GetEnumDescription()
            };

            string[] maritalStatus = new string[]
            {
                MaritalStatus.Married.GetEnumDescription(),
                MaritalStatus.NotMarried.GetEnumDescription()
            };

            string[] educationLevels = new string[]
            {
                EducationLevels.HighSchoolOrLess.GetEnumDescription(),
                EducationLevels.SomeCollege.GetEnumDescription(),
                EducationLevels.BachelorsOrHigher.GetEnumDescription()
            };

            foreach (var result in resultsFromRepo)
            {
                result.MarriedOrNotMarried = maritalStatus;
                result.EducationLevels = educationLevels;
                result.PopulationOfEachGroup = populationOfEachGroup;
            }

            MarriageRatesByEducationResponse response = new MarriageRatesByEducationResponse() 
            { 
                Ethnicities = ethnicities,
                MarriageRatesResults = resultsFromRepo
            };
            return response;
        }
    }
}