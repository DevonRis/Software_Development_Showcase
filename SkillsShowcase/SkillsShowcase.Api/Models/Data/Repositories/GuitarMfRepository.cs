using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class GuitarMfRepository(AppDbContext appDbContext)
    {
        internal async Task<GuitarManufactureDetailsForApiCall[]> GetGuitarMfDetailsForRepository()
        {
            var result = await appDbContext.GuitarManufactureDetails.ToArrayAsync();
            return result.Select(guitarMf => new GuitarManufactureDetailsForApiCall
            {
                GuitarManufacturerId = guitarMf.GuitarManufacturerId,
                ManufacturerName = guitarMf.ManufacturerName,
                Location = guitarMf.Location,
                ContactNumber = guitarMf.ContactNumber,
                Email = guitarMf.Email,
                Website = guitarMf.Website,
                DateEstablished = guitarMf.DateEstablished,
            }).ToArray();
        }
    }
}