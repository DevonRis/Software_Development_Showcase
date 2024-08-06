using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages.LayeredPages.DcVillainsLayeredComponents
{
    public partial class DcVillainsCardCarousel : ComponentBase
    {
        [Inject]
        private GetApiClient GetDcVillainsAPIs { get; set; } = default!;

        [Parameter]
        public List<DcVillainsForApiCall>? DcVillainsForCarousel { get; set; }
        [Parameter]
        public DcVillainsForApiCall? DcVillainsCarousel { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await GetApiDcVillainsForView();
        }
        private async Task GetApiDcVillainsForView()
        {
            DcVillainsForCarousel = await GetDcVillainsAPIs.GetApiDcVillainsTable();
            foreach (var dcVillainProperty in DcVillainsForCarousel)
            {
                DcVillainsCarousel = dcVillainProperty;
            }
        }
    }
}
