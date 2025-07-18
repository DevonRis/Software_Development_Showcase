namespace SkillsShowcase.Shared.Domain.Data
{
    public static class CustomConstatnts
    {
        //Decimal Constants
        public const decimal HighSchoolOrLess_Whites = 0.89m;
        public const decimal HighSchoolOrLess_Asians = 0.94m;
        public const decimal HighSchoolOrLess_AfricanAmericans = 0.81m;
        public const decimal HighSchoolOrLess_Hispanics = 0.78m;

        public const decimal MarriedWhiteHouseHolds_HS = 0.51m;
        public const decimal MarriedAsianHouseHolds_HS = 0.55m;
        public const decimal MarriedBlackHouseHolds_HS = 0.26m;
        public const decimal MarriedHispanicHouseHolds_HS = 0.27m;

        //String Array constants
        public static readonly string[] TopDegrees_Asians = new[]
        {
            "BS in Biology",
            "BS in Computer Science",
            "BS in Business Administration",
            "BS in Nursing",
            "BS in Mechanical Engineering"
        };
        public static readonly string[] TopDegrees_Whites = new[]
        {
            "BS in Business Administration",
            "BS in Nursing",
            "BA in Psychology",
            "BA in Economics",
            "BS in Biology"
        };

        public static readonly string[] TopDegrees_Blacks = new[]
        {
            "BS in Nursing",
            "BS in Business Administration",
            "BS in Criminal Justice",
            "BA in Psychology",
            "BSW in Social Work"
        };

        public static readonly string[] TopDegrees_Hispanics = new[]
        {
            "BS in Business Administration",
            "BS in Nursing",
            "BA in Psychology",
            "BA in Sociology",
            "BS in Education"
        };
    }
}
