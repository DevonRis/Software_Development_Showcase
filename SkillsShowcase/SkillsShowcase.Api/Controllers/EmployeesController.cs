using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _employeeDbContext;
        public EmployeesController(AppDbContext employeeDbContext) => _employeeDbContext = employeeDbContext;

        //CRUD Operations: "Get" from Database
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employeeDbContext.Employees;
        }
        //CRUD Operations: "Create/New" from Database
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee?>> GetById(int id)
        {
            return await _employeeDbContext.Employees.Where(x => x.EmployeeId == id).SingleOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee employees)
        {
            await _employeeDbContext.Employees.AddAsync(employees);
            await _employeeDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = employees.EmployeeId }, employees);
        }
        //CRUD Operations: "Update" from Database
        [HttpPut]
        public async Task<ActionResult> Update(Employee employees)
        {
            _employeeDbContext.Employees.Update(employees);
            await _employeeDbContext.SaveChangesAsync();
            return Ok();
        }
        //CRUD Operations: "Delete" from Database
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employeeGetByIdResult = await GetById(id);
            if (employeeGetByIdResult.Value is null)
                return Ok();
            _employeeDbContext.Remove(employeeGetByIdResult.Value);
            await _employeeDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
