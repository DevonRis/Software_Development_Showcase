using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages.LayeredPages
{
    public partial class DataCardsForHomePage : ComponentBase
    {
        [Inject]
        private GetApiClient ApiClient { get; set; } = default!;
        [Parameter]
        public FirstQuarterRevenueForApiCall[] MonthlyRevenuesForDataCards { get; set; } = null!;
        [Parameter]
        public int MonthRevenue { get; set; }
        protected async override Task OnInitializedAsync() 
        { 
            await GetMonthlyRevenuesForDataCards();
        }
        private async Task GetMonthlyRevenuesForDataCards()
        {
            var response = await ApiClient.GetFirstQuarterRevenue();
            MonthlyRevenuesForDataCards = response!.ToArray();
        }
    }
}
