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
        public ElementReference DcVillain_Card { get; set; }
        [Parameter]
        public bool StartFlipped { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (StartFlipped && firstRender)
            {
                await FlipCard();
            }
        }
        private async Task DcVillainsFor()
        {
            DcVillainsForCards = await GetDcVillainsAPIs.GetApiDcVillainsTable();
            await FlipCard();
        }
        public async Task FlipCard()
        {
            await JSRuntime.InvokeVoidAsync("flipCard", DcVillain_Card);
        }
    }
}
