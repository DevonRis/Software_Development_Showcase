using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        private readonly GuitarService _guitarService;

        public GuitarController(GuitarService guitarService)
        {
            _guitarService = guitarService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Guitars>> Get()
        {
            GetGuitarsResponse response = _guitarService.GetGuitars();
            return Ok(response.Guitars);
        }
    }
}
