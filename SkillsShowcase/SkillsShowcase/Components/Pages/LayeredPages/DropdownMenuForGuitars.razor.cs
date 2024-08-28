using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.Models.Enums;
using SkillsShowcase.Shared.Domain.Models.MethodExtensions;

namespace SkillsShowcase.Components.Pages.LayeredPages
{
    public partial class DropdownMenuForGuitars : ComponentBase
    {
        [Inject]
        private GetApiClient GetApiClient { get; set; }
        [Parameter]
        public List<GuitarsForApiCall>? GuitarsForDropdown { get; set; }
        [Parameter]
        public List<GuitarOptions>? GuitarManufacterOptions { get; set; }
        [Parameter]
        public EventCallback<GuitarOptions> SelectedGuitar { get; set; }
        public GuitarOptions _selectedGuitarOption { get; set; }
        public GuitarOptions SelectedGuitarOption
        {
            get => _selectedGuitarOption;
            set
            {
                if (_selectedGuitarOption != value)
                {
                    _selectedGuitarOption = value;
                    ProcessSelectedGuitarValue(value);
                }
            }
        }
        private string GetEnums(GuitarOptions guitarValue)
        {
            return guitarValue.GetEnumDescription();
        }
        protected async override Task OnInitializedAsync()
        {
            await GetGuitarsForGuitarsDisplayView();
            SelectedGuitarOption = GuitarOptions.NoModel;
        }
        private async Task GetGuitarsForGuitarsDisplayView()
        {
            GuitarsForDropdown = await GetApiClient.GetApiGuitars();
        }
        private void ProcessSelectedGuitarValue(GuitarOptions guitarValue)
        {
            SelectedGuitar.InvokeAsync(SelectedGuitarOption);
        }
    }
}
