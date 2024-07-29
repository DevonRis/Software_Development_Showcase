using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Interfaces;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeeRepository)
        {
            _employeesRepository = employeeRepository;
        }
        //Gets ALL EMPLOYEES
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeesRepository.GetAllEmployees());
        }
        //Gets all employees by ID
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_employeesRepository.GetEmployeeById(id));
        }
        //For creating an Employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEmployee = _employeesRepository.AddEmployee(employee);

            return Created("employee", createdEmployee);
        }
        //Updates Employee
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeToUpdate = _employeesRepository.GetEmployeeById(employee.EmployeeId);

            if (employeeToUpdate == null)
                return NotFound();

            _employeesRepository.UpdateEmployee(employee);

            return NoContent(); //success
        }
        //Delets an Employee
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0)
                return BadRequest();

            var employeeToDelete = _employeesRepository.GetEmployeeById(id);
            if (employeeToDelete == null)
                return NotFound();

            _employeesRepository.DeleteEmployee(id);

            return NoContent();//success
        }
    }
}
