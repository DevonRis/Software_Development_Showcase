using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
    }
}
