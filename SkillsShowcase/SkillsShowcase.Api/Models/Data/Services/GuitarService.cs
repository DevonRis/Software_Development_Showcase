﻿using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class GuitarService(GuitarRepository guitarRepository)
    {
        public GetGuitarsResponse GetGuitars()
        {
            return guitarRepository.GetGuitars();
        }
    }
}
