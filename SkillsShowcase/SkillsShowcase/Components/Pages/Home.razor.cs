using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        private GetApiClient? ApiClient { get; set; }
        [Parameter]
        public List<SessionLogsForApiCall> SessionLogsInfoForHomePage { get; set; }
        [Parameter]
        public Dictionary<DateOnly, int> DailySessionsDataForHomePageGraph { get; set; } = null!;
        [Parameter]
        public SoldVsInProcessCarInfoLogsForApiCall[] CarPurchaseInfoLogsForHomeBarGraph { get; set; } = null!;
        public int SoldCars { get; set; }
        public int InProcessCars { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetSoldVsInProcessForBarGraph();
            }
        }
        protected async override Task OnInitializedAsync()
        {
            await GetNeededDataForGraph();
            await GetSoldVsInProcessForBarGraph();
        }
        private async Task GetNeededDataForGraph()
        {
            SessionLogsInfoForHomePage = await ApiClient.GetApiSessionLogs();
            DailySessionsDataForHomePageGraph = SessionLogsInfoForHomePage
                .GroupBy(x => DateOnly.FromDateTime(x.CreatedTime))
                .ToDictionary(x => x.Key, x => x.Sum(y => y.SessionCountsPerDate));
        }
        private async Task GetSoldVsInProcessForBarGraph()
        {
            var response = await ApiClient.GetCarPurchaseInfoLogs();
            CarPurchaseInfoLogsForHomeBarGraph = response!.ToArray();
            SoldCars = CarPurchaseInfoLogsForHomeBarGraph
                .Where(cars => cars.SoldCars == 1).Count();
            InProcessCars = CarPurchaseInfoLogsForHomeBarGraph
                .Where(cars => cars.InProcessCars == 1).Count();
        }
    }
}