using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;
using SkillsShowcase.Api.Models.Data.Services;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPurchaseInfoLogsController : ControllerBase
    {
        private readonly CarInfoLogsService _carInfoLogsService;
        public CarPurchaseInfoLogsController(CarInfoLogsService carInfoLogsService)
        {
            _carInfoLogsService = carInfoLogsService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarPurchaseInfoLog>>> Get()
        {
            GetCarPurchaseInfoLogsResponse response = await _carInfoLogsService.GetSoldVsInProcessCarInfoLogs();
            return Ok(response.CarPurchaseInfoLogs);
        }
    }
}
