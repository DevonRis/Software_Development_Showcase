using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum EducationLevels
    {
        [Description("High School or Less")]
        HighSchoolOrLess = 1,
        [Description("Bachelor's +")]
        BachelorsOrHigher = 2,
    }
}
