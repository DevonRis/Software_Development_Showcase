using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DcVillainsController : ControllerBase
    {
        private readonly AppDbContext _dcVillainsDbContext;
        public DcVillainsController(AppDbContext dcVillainsDbContext)
        {
            _dcVillainsDbContext = dcVillainsDbContext;
        }

        //CRUD Operations: "Get" from Database
        [HttpGet]
        public ActionResult<IEnumerable<DcVillains>> Get()
        {
            return _dcVillainsDbContext.DcVillains;
        }
        //CRUD Operations: "Update" from Database
        [HttpPut]
        public async Task<ActionResult> Update(DcVillains dcVillains)
        {
            _dcVillainsDbContext.DcVillains.Update(dcVillains);
            await _dcVillainsDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
