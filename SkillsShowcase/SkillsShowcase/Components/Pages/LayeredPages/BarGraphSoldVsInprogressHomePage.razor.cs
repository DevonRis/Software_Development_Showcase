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
        [Parameter]
        public int SoldCars { get; set; }
        [Parameter]
        public int InProcessCars { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetSoldVsInProcessForBarGraph();
                await RenderBarChart();
            }
        }
        private async Task GetSoldVsInProcessForBarGraph()
        {
            var response = await ApiClient.GetCarPurchaseInfoLogs();
            CarPurchaseInfoLogsForBarGraph = response!.ToArray();
            SoldCars = CarPurchaseInfoLogsForBarGraph
                .Where(cars => cars.SoldCars == 1).Count();
            InProcessCars = CarPurchaseInfoLogsForBarGraph
                .Where(cars => cars.InProcessCars == 1).Count();
        }
        [JSInvokable]
        private async Task RenderBarChart()
        {
            await JSRuntime.InvokeVoidAsync("renderBarChartTwo", SoldCars, InProcessCars);
        }
    }
}
