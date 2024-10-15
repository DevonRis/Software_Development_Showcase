using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class NarutoInfoService(NarutoInfoRepository narutoInfoRepository)
    {
        public async Task<NarutoInfoResponse> GetNarutoInfo() 
        { 
            var narutoInfoData = await narutoInfoRepository.GetNarutInfoForRepository();
            return new NarutoInfoResponse
            {
                NarutoInfo = narutoInfoData
            };
        }
    }
}
