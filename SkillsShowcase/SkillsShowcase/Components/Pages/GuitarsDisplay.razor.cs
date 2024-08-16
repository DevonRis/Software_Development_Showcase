using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class GuitarsDisplay : ComponentBase
    {
        [Inject]
        private GetApiClient? GetGuitarsAPIs { get; set; }
        [Parameter]
        public List<GuitarsForApiCall>? GuitarsForGuitarDisplayPage { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await GetGuitarsForGuitarsDisplayView();
        }
        private async Task GetGuitarsForGuitarsDisplayView()
        {
            GuitarsForGuitarDisplayPage = await GetGuitarsAPIs.GetApiGuitars();
        }
    }
}
