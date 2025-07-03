using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class UsDemographics
    {
        [Key]
        public int Id { get; set; }
        public int TotalPopulation { get; set; }
        public decimal WhitesPopulation { get; set; }
        public decimal HispanicsPopulation { get; set; }
        public decimal AsiansPopulation { get; set; }
        public decimal AfricanAmericanPopulation { get; set; }
        public decimal BlackMenPopulation { get; set; }
        public decimal BlackWomenPopulation { get; set; }
        public decimal BlackMenWithBachelors { get; set; }
        public decimal BlackWomenWithBachelors { get; set; }
        public decimal BlackMenWithGradDegrees { get; set; }
        public decimal BlackWomenWithGradDegrees { get; set; }
        public decimal WhitesWithBachelors { get; set; }
        public decimal WhitesWithGradDegrees { get; set; }
        public decimal HispanicsWithBachelors { get; set; }
        public decimal HispanicsWithGradDegrees { get; set; }
        public decimal AsiansWithBachelors { get; set; }
        public decimal AsiansWithGradDegrees { get; set; }
        public decimal WhiteHouseHoldsThatsMarried { get; set; }
        public decimal BlackHouseHoldsThatsMarried { get; set; }
        public decimal HispanicHouseHoldsThatsMarried { get; set; }
        public decimal AsianHouseHoldsThatsMarried { get; set; }
        public decimal WhiteUpperMiddleClassPercentage { get; set; }
        public decimal BlackUpperMiddleClassPercentage { get; set; }
        public decimal HispanicUpperMiddleClassPercentage { get; set; }
        public decimal AsianUpperMiddleClassPercentage { get; set; }
        public decimal WhiteLowerMiddleClassPercentage { get; set; }
        public decimal BlackLowerMiddleClassPercentage { get; set; }
        public decimal HispanicLowerMiddleClassPercentage { get; set; }
        public decimal AsianLowerMiddleClassPercentage { get; set; }
    }
}