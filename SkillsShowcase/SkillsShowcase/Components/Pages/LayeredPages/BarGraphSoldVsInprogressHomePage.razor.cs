using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages.LayeredPages
{
    public partial class BarGraphSoldVsInprogressHomePage : ComponentBase
    {
        [Inject]
        private GetApiClient ApiClient { get; set; } = default!;
        [Inject]
        private IJSRuntime JSRuntime { get; set; }
        [Parameter]
        public SoldVsInProcessCarInfoLogsForApiCall[] CarPurchaseInfoLogsForBarGraph { get; set; } = null!;
        protected async override Task OnInitializedAsync()
        {
            await GetSoldVsInProcessForBarGraph();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await RenderBarChart();
            }
        }
        private async Task GetSoldVsInProcessForBarGraph()
        {
            var response = await ApiClient.GetCarPurchaseInfoLogs();
            CarPurchaseInfoLogsForBarGraph = response.ToArray();
        }
        private async Task RenderBarChart()
        {
            await JSRuntime.InvokeVoidAsync("renderBarChart", CarPurchaseInfoLogsForBarGraph);
        }
    }
}
