﻿using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class CarInfoLogsRepository(AppDbContext appDbContext)
    {
        internal async Task<SoldVsInProcessCarInfoLogsForApiCall[]> GetSoldVsInProcessCarRepositoryInfoLogs()
        {
            var result = await appDbContext.CarPurchaseInfoLogs
                .GroupBy(x => x.CarModel)
                .Select(x => new SoldVsInProcessCarInfoLogsForApiCall
                {
                    CarModel = x.Key,
                    SoldCars = x.Count(y => y.CarPurchaseStatus == CarPurchaseEventTypeOption.CarSold),
                    InProcessCars = x.Count(y => y.CarPurchaseStatus == CarPurchaseEventTypeOption.CarPurchaseInProcess)
                })
                .ToArrayAsync();
            return result;
        }
    }
}