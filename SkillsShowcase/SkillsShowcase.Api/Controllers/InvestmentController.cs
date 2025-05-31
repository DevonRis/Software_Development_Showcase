using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly InvestmentService _service;

        public InvestmentController(InvestmentService service)
        {
            _service = service;
        }

        [HttpPost("GetInvestmentResults")]
        public async Task<ActionResult> GetInvestmentResults([FromBody] InvestmentResultsRequest request)
        {
            var results = await _service.ResultsFromRepo(request);
            return Ok(results);
        }
    }
}
