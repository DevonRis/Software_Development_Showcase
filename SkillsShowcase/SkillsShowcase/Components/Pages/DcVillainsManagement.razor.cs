using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Components.Pages
{
    public partial class DcVillainsManagement : ComponentBase
    {
        [Inject]
        private GetApiClient GetDcVillainsAPIs { get; set; } = default!;
        [Parameter]
        public List<DcVillainsForApiCall>? DcVillainsForMainPage { get; set; }
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

        public bool HasMatchingVillains { get; set; } = true;
        protected async override Task OnInitializedAsync()
        {
            await GetApiDcVillainsForView();
        }
        private async Task GetApiDcVillainsForView()
        {
            DcVillainsForMainPage = await GetDcVillainsAPIs.GetApiDcVillainsTable();
            FilterPlans();
        }
        public async void FilterPlans()
        {
            DcVillainsNameList = DcVillainsForMainPage
                .Where(villains => villains.VillanName.ToLower()
                .Contains(SearchText.ToLower()))
                .Select(villains => villains.VillanName)
                .ToList();

            HasMatchingVillains = DcVillainsNameList.Any(villainName => villainName.Equals(SearchText, StringComparison.OrdinalIgnoreCase));
        }
    }
}
