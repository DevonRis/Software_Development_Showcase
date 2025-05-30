using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum MartialArts
    {
        [Description("")]
        NoStyle,
        [Description("Karate")]
        Karate,
        [Description("Taekwondo")]
        Taekwondo,
        [Description("Brazilian Jiu-Jitsu")]
        BrazilianJiuJitsu,
        [Description("Mixed Martial Arts")]
        MixedMartialArts,
        [Description("Judo")]
        Judo,
        [Description("Eskrima")]
        Eskrima,
        [Description("Muay Thai")]
        MuayThai,
        [Description("Krav Maga")]
        KravMaga,
        [Description("Capoeira")]
        Capoeira,
        [Description("Boxing")]
        Boxing
    }
}
