using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Components.Pages
{
    public partial class GuitarsDisplay : ComponentBase
    {
        [Inject]
        private GetApiClient? GetGuitarsAPIs { get; set; }
        [Parameter]
        public List<GuitarsForApiCall>? GuitarsForGuitarDisplayPage { get; set; }
        private GuitarOptions? SelectedGuitarOptionInCard;
        protected async override Task OnInitializedAsync()
        {
            await GetGuitarsForGuitarsDisplayView();
        }
        private async Task GetGuitarsForGuitarsDisplayView()
        {
            GuitarsForGuitarDisplayPage = await GetGuitarsAPIs.GetApiGuitars();
        }
        private void HandleIncomingGuitarOptionValue(GuitarOptions selectedGuitarOptionsValue) 
        { 
            SelectedGuitarOptionInCard = selectedGuitarOptionsValue;
        }
        private IEnumerable<GuitarsForApiCall>? GetFilteredGuitars() 
        {
            if (SelectedGuitarOptionInCard.HasValue) 
            {
                if (SelectedGuitarOptionInCard == GuitarOptions.NoModel) 
                {
                    return GuitarsForGuitarDisplayPage;
                }
                else 
                {
                    return GuitarsForGuitarDisplayPage?.Where(option => option.GuitarManufacturer == SelectedGuitarOptionInCard);
                }
            }
            return GuitarsForGuitarDisplayPage;
        }
    }
}
