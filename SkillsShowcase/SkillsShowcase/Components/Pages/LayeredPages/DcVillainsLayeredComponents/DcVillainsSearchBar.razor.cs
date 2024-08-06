using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages.LayeredPages.DcVillainsLayeredComponents
{
    public partial class DcVillainsSearchBar : ComponentBase
    {
        [Inject]
        private GetApiClient GetDcVillainsAPIs { get; set; } = default!;
        [Parameter]
        public List<DcVillainsForApiCall>? DcVillainsForSearchBar { get; set; }
        [Parameter]
        public List<string>? DcVillainsNameList { get; set; }
        public string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    FilterPlans();
                }
            }
        }
        protected async override Task OnInitializedAsync()
        {
            await GetApiDcVillainsForView();
        }
        private async Task GetApiDcVillainsForView()
        {
            DcVillainsForSearchBar = await GetDcVillainsAPIs.GetApiDcVillainsTable();
            FilterPlans();
        }
        public void FilterPlans() 
        {
            DcVillainsNameList = DcVillainsForSearchBar
                .Where(villains => villains.VillanName.ToLower()
                .Contains(SearchText.ToLower()))
                .Select(villains => villains.VillanName)
                .ToList();
        }
    }
}
