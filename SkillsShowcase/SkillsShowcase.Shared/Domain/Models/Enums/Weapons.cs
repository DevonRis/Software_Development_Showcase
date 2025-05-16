using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum Weapons
    {
        [Description("")]
        NoWeapon,
        [Description("Pistol")]
        Glock19,
        [Description("Revolver")]
        SmithWesson500,
        [Description("Sniper rifle")]
        Remington700,
        [Description("Shotgun")]
        Mossberg500,
        [Description("Katana")]
        Katana,
        [Description("Longsword")]
        Longsword,
        [Description("Recurve bow")]
        RecurveBow,
        [Description("Crossbow")]
        Crossbow,
        [Description("Knife")]
        KaBarKnife,
        [Description("Battle axe")]
        BattleAxe
    }
}
