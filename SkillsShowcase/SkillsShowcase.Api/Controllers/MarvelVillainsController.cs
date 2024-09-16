using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.Services;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarvelVillainsController : ControllerBase
    {
        private readonly MarvelVillainsService _marvelVillainsService;

        public MarvelVillainsController(MarvelVillainsService marvelVillainsService)
        {
            _marvelVillainsService = marvelVillainsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _marvelVillainsService.GetMarvelVillainsConfirmedKills();
            return Ok(response.MarvelVillainsConfirmedKills);
        }
    }
}
