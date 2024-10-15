using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Components.Pages.LayeredPages.NarutoInfoSubComponents
{
    public partial class CharactersBioModal : ComponentBase
    {
        [Parameter]
        public NarutoCharacterDetails NarutoCharacterDetails { get; set; } = default!;
        [Parameter]
        public EventCallback OnClose { get; set; }
        private bool IsVisible { get; set; }
        public void Show(int characterID)
        {
            if (characterID != 0)
            {
                NarutoCharacterDetails.NarutoCharacterId = characterID;
                IsVisible = true;
                StateHasChanged();
            }
        }
        private async Task CloseModal()
        {
            IsVisible = false;
            if (OnClose.HasDelegate)
            {
                await OnClose.InvokeAsync(null);
            }
        }
    }
}
