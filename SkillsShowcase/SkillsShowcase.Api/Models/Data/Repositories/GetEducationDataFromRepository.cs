using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SkillsShowcase.Shared.Domain.Data;
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
        internal async Task<(MarriageRatesByEducationResults[]? Results, int[] PopulationOfEachGroup)> GetMarriageDataFromRepository(MarriageByEducationRequest request, int[] populationOfEachGroup)
        {
            UsDemographics[]? demographics = await appDbContext.UsDemographics.ToArrayAsync();

            int totalPopulation = demographics.Select(x => x.TotalPopulation)
                .FirstOrDefault();

            var groupedPopulationsPercentages = demographics.Select(data => new
            {
                data.WhitesPopulation,
                data.AfricanAmericanPopulation,
                data.HispanicsPopulation,
                data.AsiansPopulation,
            }).ToArray();

            // Calculate the populations for each group based on the percentages and total population
            List<int> populations = new();
            foreach (var percent in groupedPopulationsPercentages)
            {
                int whitePopulation = (int)Math.Round(totalPopulation * percent.WhitesPopulation);
                int africanAmericanPopulation = (int)Math.Round(totalPopulation * percent.AfricanAmericanPopulation);
                int hispanicPopulation = (int)Math.Round(totalPopulation * percent.HispanicsPopulation);
                int asianPopulation = (int)Math.Round(totalPopulation * percent.AsiansPopulation);

                populations.Add(whitePopulation);
                populations.Add(africanAmericanPopulation);
                populations.Add(hispanicPopulation);
                populations.Add(asianPopulation);
            }
            // Assign the calculated populations to the input array reference
            populationOfEachGroup = populations.ToArray();

             int marriedWhitesHSD = (int)Math.Round(populationOfEachGroup[0] * CustomConstatnts.MarriedWhiteHouseHolds_HS);
            int marriedAsiansHSD = (int)Math.Round(populationOfEachGroup[3] * CustomConstatnts.MarriedAsianHouseHolds_HS);
            int marriedBlacksHSD = (int)Math.Round(populationOfEachGroup[1] * CustomConstatnts.MarriedBlackHouseHolds_HS);
            int marriedHispanicsHSD = (int)Math.Round(populationOfEachGroup[2] * CustomConstatnts.MarriedHispanicHouseHolds_HS);

            var groupedMarriedCouplesPercentages = demographics.Select(data => new
            {
                data.WhiteHouseHoldsThatsMarried,
                data.BlackHouseHoldsThatsMarried,
                data.HispanicHouseHoldsThatsMarried,
                data.AsianHouseHoldsThatsMarried,
            }).ToArray();

            var results = new List<MarriageRatesByEducationResults>();

            foreach (var percent in groupedMarriedCouplesPercentages)
            {
                var whiteHouseholds = (int)Math.Round(populationOfEachGroup[0] * percent.WhiteHouseHoldsThatsMarried);
                var blackHouseholds = (int)Math.Round(populationOfEachGroup[1] * percent.BlackHouseHoldsThatsMarried);
                var hispanicHouseholds = (int)Math.Round(populationOfEachGroup[2] * percent.HispanicHouseHoldsThatsMarried);
                var asianHouseholds = (int)Math.Round(populationOfEachGroup[3] * percent.AsianHouseHoldsThatsMarried);

                results.Add(new MarriageRatesByEducationResults
                {
                    WhiteMarriedCouples = whiteHouseholds,
                    BlackMarriedCouples = blackHouseholds,
                    HispanicMarriedCouples = hispanicHouseholds,
                    AsianMarriedCouples = asianHouseholds,
                    WhitesMarriedHSD = marriedWhitesHSD,
                    BlacksMarriedHSD = marriedBlacksHSD,
                    HispanicsMarriedHSD = marriedHispanicsHSD,
                    AsiansMarriedHSD = marriedAsiansHSD
                });
            }
            return (results.ToArray(), populationOfEachGroup);
        }
    }
}