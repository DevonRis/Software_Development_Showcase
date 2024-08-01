using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class EmployeeSecretsPopUpView
    {
        private EmployeeSecretKeyForApiCall? _getEmployeeSecretsForView { get; set; } = default!;
        [Parameter]
        public EmployeeSecretKeyForApiCall? EmployeeSecretsForView { get; set; }
        [Parameter]
        public EventCallback<EmployeeSecretKeyForApiCall> EmployeeCompanySecretKeyClicked { get; set; }
        /*protected async override Task OnInitializedAsync() 
        { 
        
        }*/
        protected override void OnParametersSet()
        {
            _getEmployeeSecretsForView = EmployeeSecretsForView;
        }

        public void Close()
        {
            _getEmployeeSecretsForView = null;
        }
    }
}
