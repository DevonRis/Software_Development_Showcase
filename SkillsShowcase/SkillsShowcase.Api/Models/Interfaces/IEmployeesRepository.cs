using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.Interfaces
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        //IEnumerable<EmployeeListModel> GetLongEmployeeList();
        //IEnumerable<EmployeeListModel> GetTakeLongEmployeeList(int request, int count);
    }
}
