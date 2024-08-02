using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class EmployeeDisplay : ComponentBase
    {
        [Inject]
        private GetApiClient GetSecretsAPIs { get; set; } = default!;
        [Inject]
        private GetApiClient GetEmployeesAPIs { get; set; } = default!;

        private EmployeeSecretsModal? employeeSecretsModal;

        [Parameter]
        public List<Employee>? Employees { get; set; }
        [Parameter]
        public List<EmployeeSecretKeyForApiCall>? EmployeeSecrets { get; set; }

        protected async override Task OnInitializedAsync() 
        {
            await GetApiEmployeesForView();
        }
        private async Task GetApiEmployeesForView() 
        {
            Employees = await GetEmployeesAPIs.GetApiEmployeesTable();
        }
        private async Task ShowEmployeeSecretsModal()
        {
            EmployeeSecrets = await GetSecretsAPIs.GetApiEmployeeSecretKeys();
            employeeSecretsModal.Show(EmployeeSecrets);
        }
    }
}
