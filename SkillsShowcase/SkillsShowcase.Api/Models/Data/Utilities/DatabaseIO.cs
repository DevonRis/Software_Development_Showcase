using SkillsShowcase.Shared.Domain.Models;

namespace SkillsShowcase.Api.Models.Data.Utilities
{
    public class DatabaseIO
    {
        private readonly AppDbContext _appDbContext;

        public DatabaseIO(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<SearchRatesWithEFLDetails_Result> SearchRatesWithEFLDetails(int? tdspID, int? repID, decimal? averagePricePer500kWh, decimal? averagePricePer1000kWh, decimal? averagePricePer2000kWh, int lengthOfTerm, string eflTypeProduct, decimal? averagePricePerkWhTolerance)
        {
            var storedProcedureResults = _appDbContext
                .SearchRatesWithEFLDetailsAsync(tdspID, repID, averagePricePer500kWh, averagePricePer1000kWh, averagePricePer2000kWh, lengthOfTerm, eflTypeProduct, averagePricePerkWhTolerance);
            return storedProcedureResults.Result;
        }
    }
}
