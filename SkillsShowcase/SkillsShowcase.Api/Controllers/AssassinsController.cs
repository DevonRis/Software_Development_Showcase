using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Save;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssassinsController : ControllerBase
    {
        private readonly AssassinsService _assassinsService;
        public AssassinsController(AssassinsService assassinsService)
        {
            _assassinsService = assassinsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            AssassinsResponse response = await _assassinsService.GetAssassinsFromRepo();
            return Ok(response.Assassins);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AssassinsPostRequest assassinsPostRequest)
        {
            await _assassinsService.CreateAssassin(assassinsPostRequest);
            return Ok();
        }
        [HttpPost("GetAssignedAssassin")]
        public async Task<IActionResult> GetAssignedAssassin([FromBody] GetAssassinRequest request)
        {
            var response = await _assassinsService.GetAssignedAssassin(request);
            return Ok(response.AssignedAssassin);
        }
    }
}
