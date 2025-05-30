namespace SkillsShowcase.Shared.Domain.Models.MethodExtensions
{
    public class DecimalHelper
    {
        public decimal NormalizeDecimal(decimal value)
        {
            return value > 1 ? value / 100 : value;
        }
    }
}
