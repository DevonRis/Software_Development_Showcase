using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class DcVillainsManagement : ComponentBase
    {
        [Inject]
        private GetApiClient GetDcVillainsAPIs { get; set; } = default!;
        [Parameter]
        public List<DcVillainsForApiCall>? DcVillainsForMainPage { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await GetApiDcVillainsForView();
        }
        private async Task GetApiDcVillainsForView()
        {
            DcVillainsForMainPage = await GetDcVillainsAPIs.GetApiDcVillainsTable();
        }
    }
}
