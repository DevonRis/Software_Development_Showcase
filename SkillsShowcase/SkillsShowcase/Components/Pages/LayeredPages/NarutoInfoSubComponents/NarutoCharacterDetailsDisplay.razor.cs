using Microsoft.AspNetCore.Components;
using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Components.Pages.LayeredPages.NarutoInfoSubComponents
{
    public partial class NarutoCharacterDetailsDisplay : ComponentBase
    {
        [Parameter]
        public NarutoCharacterDetails NarutoCharacterDetails { get; set; } = default!;
        private CharactersBioModal? charactersBioModal;
        private void ShowCharacterBioModal(int characterID)
        {
            if (charactersBioModal != null)
            {
                charactersBioModal.Show(characterID);
            }
        }
    }
}
