using Microsoft.AspNetCore.Components;

namespace SkillsShowcase.Components.Pages.LayeredPages
{
    public partial class HorizontalSlider : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
