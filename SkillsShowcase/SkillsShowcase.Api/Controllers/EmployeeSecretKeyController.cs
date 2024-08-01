using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSecretKeyController : ControllerBase
    {
        private readonly AppDbContext _employeeSecretKeysDbContext;

        public EmployeeSecretKeyController(AppDbContext employeeSecretKeysDbContext)
        {
            _employeeSecretKeysDbContext = employeeSecretKeysDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeSecretKey>> Get() 
        {
            return _employeeSecretKeysDbContext.EmployeeSecretKeys;
        }
    }
}
