using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.Services;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPurchaseInfoLogsController : ControllerBase
    {
        private readonly CarInfoLogsService _carInfoLogsService;

        public CarPurchaseInfoLogsController(CarInfoLogsService service)
        {
            _carInfoLogsService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _carInfoLogsService.GetSoldVsInProcessCarInfoLogs();
            return Ok(response.CarPurchaseInfoLogs);
        }
    }
}
