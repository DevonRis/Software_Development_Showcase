using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum RaceDemographics
    {
        [Description("Whites")]
        Whites = 1,
        [Description("Asians")]
        Asians = 2,
        [Description("African Americans")]
        AfricanAmericans = 3,
        [Description("Hispanics")]
        Hispanics = 4,
        [Description("Black Men")]
        BlackMen = 5,
        [Description("Black Women")]
        BlackWomen = 6
    }
}