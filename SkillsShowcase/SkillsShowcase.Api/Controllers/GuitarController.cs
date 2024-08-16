using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        private readonly AppDbContext _guitarsDbContext;

        public GuitarController(AppDbContext guitarsDbContext) 
        { 
            _guitarsDbContext = guitarsDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Guitars>> Get() 
        {
            return _guitarsDbContext.Guitars;
        }
    }
}
