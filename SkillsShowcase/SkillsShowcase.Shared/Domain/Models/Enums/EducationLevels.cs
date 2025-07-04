using System.ComponentModel;

namespace SkillsShowcase.Shared.Domain.Models.Enums
{
    public enum EducationLevels
    {
        [Description("High School or Less")]
        HighSchoolOrLess = 1,
        [Description("Some College")]
        SomeCollege = 2,
        [Description("Bachelor's +")]
        BachelorsOrHigher = 3,
    }
}
