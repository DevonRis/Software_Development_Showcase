using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.Services;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstQuarterRevenueController : ControllerBase
    {
        private readonly FirstQuarterRevenueService _firstQuarterRevenueService;
        public FirstQuarterRevenueController(FirstQuarterRevenueService service)
        {
            _firstQuarterRevenueService = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _firstQuarterRevenueService.GetFirstQuarterRevenue();
            return Ok(response.FirstQuarterRevenue);
        }
    }
}
