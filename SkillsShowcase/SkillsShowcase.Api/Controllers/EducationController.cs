using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;

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
            var results = await _service.GetEducationInfoFromRepo(request);
            return Ok(results);
        }
    }
}
