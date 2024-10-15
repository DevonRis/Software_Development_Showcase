using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages.LayeredPages.NarutoInfoSubComponents
{
    public partial class NarutoInfoAccordion : ComponentBase
    {
        [Inject]
        private GetApiClient ApiClient { get; set; } = default!;
        [Parameter]
        public NarutoInfoForApiCall[] NarutoInfoDataAccordion { get; set; } = [];
        protected async override Task OnInitializedAsync()
        {
            await GetNarutoInfoData();
        }
        private async Task GetNarutoInfoData()
        {
            var response = await ApiClient.GetNarutoInfo();
            NarutoInfoDataAccordion = response!.ToArray();
        }
    }
}
