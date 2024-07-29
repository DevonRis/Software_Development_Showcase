using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Interfaces;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.DatabaseRepository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AppDbContext _appDbContext;
        private Random random = new Random();

        //Using the Application DB Contect where seed data is located
        public EmployeesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employees;
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return _appDbContext.Employees.FirstOrDefault(c => c.EmployeeId == employeeId);
        }
        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
        public Employee UpdateEmployee(Employee employee) 
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            
            if (foundEmployee != null) 
            { 
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Email = employee.Email;
                foundEmployee.PhoneNumber = employee.PhoneNumber;
                foundEmployee.MaritalStatus = employee.MaritalStatus;
                foundEmployee.Gender = employee.Gender;

                _appDbContext.SaveChanges();
                return foundEmployee;
            }
            return null;
        }
        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }
    }
}
