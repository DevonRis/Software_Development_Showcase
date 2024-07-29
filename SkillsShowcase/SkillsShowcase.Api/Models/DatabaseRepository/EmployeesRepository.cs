using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Interfaces;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.DatabaseRepository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AppDbContext appDbContext;
        private Random random = new Random();

        //Using the Application DB Contect where seed data is located
        public EmployeesRepository(AppDbContext appDbContext)
        {
            appDbContext = appDbContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return appDbContext.Employees;
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return appDbContext.Employees.FirstOrDefault(c => c.EmployeeId == employeeId);
        }
        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
        public Employee UpdateEmployee(Employee employee) 
        {
            var foundEmployee = appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            
            if (foundEmployee != null) 
            { 
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Email = employee.Email;
                foundEmployee.PhoneNumber = employee.PhoneNumber;
                foundEmployee.MaritalStatus = employee.MaritalStatus;
                foundEmployee.Gender = employee.Gender;

                appDbContext.SaveChanges();
                return foundEmployee;
            }
            return null;
        }
        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            appDbContext.Employees.Remove(foundEmployee);
            appDbContext.SaveChanges();
        }
    }
}
