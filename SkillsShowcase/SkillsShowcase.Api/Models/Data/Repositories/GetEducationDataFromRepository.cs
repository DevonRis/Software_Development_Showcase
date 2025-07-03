using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class GetEducationDataFromRepository(AppDbContext appDbContext)
    {
        internal async Task<EducationDataFromApi[]?> GetEducationData(EducationDataRequest request)
        {
            UsDemographics[]? demographics = await appDbContext.UsDemographics.ToArrayAsync();

            int totalPopulation = demographics.Select(x => x.TotalPopulation)
                .FirstOrDefault();

            //Just concerning the African American population
            decimal blackMenWithBSPercentage = demographics.Select(x => x.BlackMenWithBachelors)
                .FirstOrDefault();
            decimal blackWomenWithBSPercentage = demographics.Select(x => x.BlackWomenWithBachelors)
                .FirstOrDefault();
            decimal blackMenWithMastersPercentage = demographics.Select(x => x.BlackMenWithGradDegrees)
                .FirstOrDefault();
            decimal blackWomenWithMastersPercentage = demographics.Select(x => x.BlackWomenWithGradDegrees)
                .FirstOrDefault();
            decimal blackMen = demographics.Select(x => x.BlackMenPopulation)
                .FirstOrDefault();
            decimal blackWomen = demographics.Select(x => x.BlackWomenPopulation)
                .FirstOrDefault();

            //Just concerning white population
            decimal whitePopulation = demographics.Select(x => x.WhitesPopulation)
                .FirstOrDefault();
            decimal whiteMenWithBSPercentage = demographics.Select(x => x.WhitesWithBachelors)
                .FirstOrDefault();
            decimal whiteMenWithMastersPercentage = demographics.Select(x => x.WhitesWithGradDegrees)
                .FirstOrDefault();

            //Just concerning Asian population
            decimal asianPopulation = demographics.Select(x => x.AsiansPopulation)
                .FirstOrDefault();
            decimal asianMenWithBSPercentage = demographics.Select(x => x.AsiansWithBachelors)
                .FirstOrDefault();
            decimal asianMenWithMastersPercentage = demographics.Select(x => x.AsiansWithGradDegrees)
                .FirstOrDefault();

            //Just concerning Hispanic Population
            decimal hispanicPopulation = demographics.Select(x => x.HispanicsPopulation)
                .FirstOrDefault();
            decimal hispanicMenWithBSPercentage = demographics.Select(x => x.HispanicsWithBachelors)
                .FirstOrDefault();
            decimal hispanicMenWithMastersPercentage = demographics.Select(x => x.HispanicsWithGradDegrees)
                .FirstOrDefault();

            //Just concerning the African American population
            decimal blackMenWithBachelors = totalPopulation * blackMen * blackMenWithBSPercentage;
            decimal blackMenWithMasters = totalPopulation * blackMen * blackMenWithMastersPercentage;
            decimal blackWomenWithBachelors = totalPopulation * blackWomen * blackWomenWithBSPercentage;
            decimal blackWomenWithMasters = totalPopulation * blackWomen * blackWomenWithMastersPercentage;

            //Just concerning white population
            decimal whiteMenWithBachelors = totalPopulation * whitePopulation * whiteMenWithBSPercentage;
            decimal whiteMenWithMasters = totalPopulation * whitePopulation * whiteMenWithMastersPercentage;

            //Just concerning Asian population
            decimal asianMenWithBachelors = totalPopulation * asianPopulation * asianMenWithBSPercentage;
            decimal asianMenWithMasters = totalPopulation * asianPopulation * asianMenWithMastersPercentage;

            //Just concerning Hispanic Population
            decimal hispanicMenWithBachelors = totalPopulation * hispanicPopulation * hispanicMenWithBSPercentage;
            decimal hispanicMenWithMasters = totalPopulation * hispanicPopulation * hispanicMenWithMastersPercentage;

            
            //Fill this bad boy up with the data
            EducationDataFromApi[]? educationData = demographics.Select(item => new EducationDataFromApi 
            {
                WhitesWithBachelors = (int)Math.Round(whiteMenWithBachelors),
                WhitesWithMasters = (int)Math.Round(whiteMenWithMasters),
                AsiansWithBachelors = (int)Math.Round(asianMenWithBachelors),
                AsiansWithMasters = (int)Math.Round(asianMenWithMasters),
                AfricanAmericansWithBachelors = (int)Math.Round(blackMenWithBachelors + blackWomenWithBachelors),
                AfricanAmericansWithMasters = (int)Math.Round(blackMenWithMasters + blackWomenWithMasters),
                HispanicsWithBachelors = (int)Math.Round(hispanicMenWithBachelors),
                HispanicsWithMasters = (int)Math.Round(hispanicMenWithMasters),
                BlackMenWithBachelors = (int)Math.Round(blackMenWithBachelors),
                BlackMenWithMasters = (int)Math.Round(blackMenWithMasters),
                BlackWomenWithBachelors = (int)Math.Round(blackWomenWithBachelors),
                BlackWomenWithMasters = (int)Math.Round(blackWomenWithMasters)
            }).ToArray();
            return educationData;
        }
    }
}
