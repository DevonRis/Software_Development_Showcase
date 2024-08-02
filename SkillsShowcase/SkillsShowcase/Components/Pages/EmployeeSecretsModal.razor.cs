using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class EmployeeSecretsModal : ComponentBase
    {
        [Parameter]
        public List<EmployeeSecretKeyForApiCall>? EmployeeSecrets { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }
        private bool IsVisible { get; set; }

        public async void Show(List<EmployeeSecretKeyForApiCall>? secrets)
        {
            EmployeeSecrets = secrets;
            IsVisible = true;
            StateHasChanged();
        }

        public void Hide()
        {
            IsVisible = false;
            StateHasChanged();
        }

        private async Task CloseModal()
        {
            IsVisible = false;
            if (OnClose.HasDelegate)
            {
                await OnClose.InvokeAsync(null);
            }
        }
    }
}
