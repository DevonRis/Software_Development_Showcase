using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionLogsController : ControllerBase
    {
        private readonly AppDbContext _sessionLogsDbContext;
        public SessionLogsController(AppDbContext sessionLogsDbContext)
        {
            _sessionLogsDbContext = sessionLogsDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SessionLogs>> Get()
        {
            return _sessionLogsDbContext.SessionLogs;
        }
    }
}
