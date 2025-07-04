using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum MaritalStatus
    {
        [Description("Married")]
        Married,
        [Description("Married with kids")]
        MarriedWithKids,
        [Description("Not Married")]
        NotMarried,
        [Description("Single")]
        Single,
        [Description("Single with kids")]
        SingleWithKids,
        Other
    }
}