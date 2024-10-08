using Microsoft.AspNetCore.Components;
using SkillsShowcase.Components.Pages.LayeredPages;
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

        private EmployeeSecretsPopUpModal? employeeSecretsModal;

        [Parameter]
        public List<EmployeeForApiCall>? Employees { get; set; }
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
        private async Task ShowEmployeeSecretsModal(int employeeId) //Must Pass in from whats clicked in the UI
        {
            EmployeeSecrets = await GetSecretsAPIs.GetApiEmployeeSecretKeys();
            
            var employeeSecrets = EmployeeSecrets?
                .Where(secrets => secrets.Id == employeeId)
                .ToList();

            employeeSecretsModal?.Show(employeeSecrets);
        }
    }
}
