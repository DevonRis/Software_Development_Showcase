using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class EmployeeDisplay : ComponentBase
    {
        [Inject]
        private GetEmployeesApiClient GetEmployeesApiClient { get; set; } = default!;

        [Parameter]
        public List<Employee>? Employees { get; set; }

        protected async override Task OnInitializedAsync() 
        {
            await GetApiEmployeesForView();
        }
        private async Task GetApiEmployeesForView() 
        {
            Employees = await GetEmployeesApiClient.GetApiEmployeesTable();
        }
    }
}
