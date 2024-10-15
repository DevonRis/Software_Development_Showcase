using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class NarutoInfo : ComponentBase
    {
        [Inject]
        private GetApiClient ApiClient { get; set; } = default!;
        [Parameter]
        public NarutoInfoForApiCall[] NarutoInfoData { get; set; } = [];
        protected async override Task OnInitializedAsync() 
        {
            await GetNarutoInfoData();
        }
        private async Task GetNarutoInfoData()
        {
            var response = await ApiClient.GetNarutoInfo();
            NarutoInfoData = response!.ToArray();
        }
    }
}
