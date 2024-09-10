﻿using SkillsShowcase.Api.Models.Data.RequestsAndResponses;

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
