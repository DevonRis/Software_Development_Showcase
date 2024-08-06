using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class EmployeeForApiCall
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
    }
}
