using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using Microsoft.JSInterop;

namespace SkillsShowcase.Components.Pages.LayeredPages.DcVillainsLayeredComponents
{
    public partial class DcVillainsCards : ComponentBase
    {
        [Inject]
        private GetApiClient GetDcVillainsAPIs { get; set; } = default!;
        [Parameter]
        public List<DcVillainsForApiCall>? DcVillainsForCards { get; set; }
        [Parameter]
        public DcVillainsForApiCall? DcVillainsCard { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await DcVillainsForCard();
        }
        private async Task DcVillainsForCard()
        {
            DcVillainsForCards = await GetDcVillainsAPIs.GetApiDcVillainsTable();
            foreach (var dcVillainProperty in DcVillainsForCards) 
            {
                DcVillainsCard = dcVillainProperty;
            }
        }
    }
}
