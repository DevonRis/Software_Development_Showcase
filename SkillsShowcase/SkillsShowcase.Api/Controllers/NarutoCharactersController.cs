using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.Services;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NarutoCharactersController : ControllerBase
    {
        private readonly NarutoInfoService _narutoInfoService;

        public NarutoCharactersController(NarutoInfoService narutoInfoService)
        {
            _narutoInfoService = narutoInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _narutoInfoService.GetNarutoInfo();
            return Ok(response.NarutoInfo);
        }
    }
}
