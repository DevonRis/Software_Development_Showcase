using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class GuitarRepository(AppDbContext appDbContext)
    {
        public GetGuitarsResponse GetGuitars()
        {
            GetGuitarsResponse response = new()
            {
                Guitars = appDbContext.Guitars
            };
            return response;
        }
    }
}
