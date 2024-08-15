using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum GuitarOptions
    {
        [Description("")]
        NotServed = 0,
        [Description("Fender")]
        Fender = 1,
        [Description("Gibson")]
        Gibson = 2,
        [Description("Paul Reed Smith")]
        PaulReedSmith = 3,
        [Description("Ibanez")]
        Ibanez = 4
    }
}
