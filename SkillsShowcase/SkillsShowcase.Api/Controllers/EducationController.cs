using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly EducationDataService _service;
        public EducationController(EducationDataService service)
        {
            _service = service;
        }

        [HttpPost("GetEducationData")]
        public async Task<ActionResult> GetEducationData([FromBody] EducationDataRequest request)
        {
            EducationDataResponse? results = await _service.GetEducationInfoFromRepo(request);
            return Ok(results);
        }
        [HttpPost("GetMarriageRatesByEducation")]
        public async Task<ActionResult> GetMarriageRatesByEducation(MarriageByEducationRequest request) 
        {
            MarriageRatesByEducationResponse? results = await _service.GetMarriageRatesDataFromRepo(request);
            return Ok(results);
        }
    }
}