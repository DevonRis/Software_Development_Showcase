using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages.LayeredPages
{
    public partial class BarGraphForHomePage : ComponentBase
    {
        [Inject]
        private GetApiClient? GetSessionLogsAPIs { get; set; }
        [Inject]
        private IJSRuntime JSRuntime { get; set; }
        [Parameter]
        public List<SessionLogsForApiCall> SessionLogsInfo { get; set; }
        [Parameter]
        public Dictionary<DateOnly, int> DailySessionsDataForBarGraph { get; set; } = null!;
        protected async override Task OnInitializedAsync() 
        {
            await GetDatesAndCountsForBarGraph();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && DailySessionsDataForBarGraph != null && DailySessionsDataForBarGraph.Any())
            {
                await RenderBarChart();
            }
        }
        private async Task GetDatesAndCountsForBarGraph()
        {
            SessionLogsInfo = await GetSessionLogsAPIs.GetApiSessionLogs();
            DailySessionsDataForBarGraph = SessionLogsInfo
                .GroupBy(x => DateOnly.FromDateTime(x.CreatedTime))
                .ToDictionary(x => x.Key, x => x.Sum(y => y.SessionCountsPerDate));
        }
        private async Task RenderBarChart()
        {
            var barChartLabels = DailySessionsDataForBarGraph.Keys
                .Select(x => x.ToString("MM/dd/yyyy"))
                .ToList();
            var barChartData = DailySessionsDataForBarGraph.Values
                .ToList();
            await JSRuntime.InvokeVoidAsync("renderBarChart", "barChartCanvasOne", barChartLabels, barChartData);
        }
    }
}
