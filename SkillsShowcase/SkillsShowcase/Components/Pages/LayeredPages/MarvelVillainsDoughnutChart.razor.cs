using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages.LayeredPages
{
    public partial class MarvelVillainsDoughnutChart : ComponentBase
    {
        [Inject]
        private GetApiClient ApiClient { get; set; } = default!;
        [Inject]
        private IJSRuntime JSRuntime { get; set; }
        [Parameter]
        public MarvelVillainsForApiCall[] MarvelVillainsForDoughnutChart { get; set; } = null!;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetMarvelVillainsConfirmedKillsForDoughnutChart();
                await RenderDoughnutChart();
            }
        }
        private async Task GetMarvelVillainsConfirmedKillsForDoughnutChart()
        {
            var response = await ApiClient.GetMarvelConfirmedKills();
            MarvelVillainsForDoughnutChart = response!.ToArray();
        }
        [JSInvokable]
        private async Task RenderDoughnutChart()
        {
            var villains = MarvelVillainsForDoughnutChart.Select(v => v.VillainName.ToString()).ToArray();
            var kills = MarvelVillainsForDoughnutChart.Select(v => v.VillainConfirmedKills).ToArray();
            await JSRuntime.InvokeVoidAsync("renderDoughnutChart", villains, kills);
        }
    }
}
