using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum NarutoCharacterStatus
    {
        [Description("Hokage")]
        Hokage = 1,
        [Description("Jonin")]
        Jonin = 2,
        [Description("Legendary Sanin")]
        LegendarySanin = 3,
        [Description("Akatsuki")]
        Akatsuki = 4,
        [Description("Mizukage")]
        Mizukage = 5,
        [Description("Kazekage")]
        Kazekage = 6,
        [Description("Tsuchikage")]
        Tsuchikage = 7,
        [Description("Raikage")]
        Raikage = 8,
        [Description("Jinchuriki")]
        Jinchuriki = 9,
    }
}
