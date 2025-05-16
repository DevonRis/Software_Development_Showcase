using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Responses;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Save;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.Requests;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class AssassinsService(AssassinsRepository assassinsRepository)
    {
        public async Task<AssassinsResponse> GetAssassinsFromRepo()
        {
            AssassinsForApiCall[]? assassinsData = await assassinsRepository.GetAssassinsFromContext();
            return new AssassinsResponse
            {
                Assassins = assassinsData
            };
        }
        public async Task CreateAssassin(AssassinsPostRequest assassinsPostRequest)
        {
            if (assassinsPostRequest.CreateAssassins != null)
            {
                await assassinsRepository.CreateNewAssassin(assassinsPostRequest.CreateAssassins);
            }
        }
        public async Task<AssignedAssassinResponse> GetAssignedAssassin(GetAssassinRequest request)
        {
            AssignedAssassinForApiCall[]? assignedAssassinData = await assassinsRepository.GetAssignedAssassinFromProc(request);
            int stop = 0;
            return new AssignedAssassinResponse
            {
                AssignedAssassin = assignedAssassinData
            };
        }
    }
}
