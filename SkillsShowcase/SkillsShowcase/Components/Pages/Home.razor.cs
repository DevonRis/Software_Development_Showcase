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
        protected async override Task OnInitializedAsync()
        {
            await GetNeededDataForGraph();
        }
        private async Task GetNeededDataForGraph()
        {
            SessionLogsInfoForHomePage = await ApiClient.GetApiSessionLogs();
            DailySessionsDataForHomePageGraph = SessionLogsInfoForHomePage
                .GroupBy(x => DateOnly.FromDateTime(x.CreatedTime))
                .ToDictionary(x => x.Key, x => x.Sum(y => y.SessionCountsPerDate));
        }
    }
}