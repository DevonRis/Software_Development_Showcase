﻿using SkillsShowcase.Shared.Domain.ApiCallOptions;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SkillsShowcase.Shared.Domain.Clients
{
    public class GetApiClient
    {
        private readonly HttpClient _httpClient;

        public GetApiClient(ApiClientOptions apiClientOptions) 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }
        //EVERYTHING WITH EMPLOYEE TABLE
        public async Task<List<EmployeeForApiCall>?> GetApiEmployeesTable()
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeForApiCall>?>("/api/Employees");
        }
        public async Task<EmployeeForApiCall?> GetApiEmployeesTableById(int id)
        {
            return await _httpClient.GetFromJsonAsync<EmployeeForApiCall?>($"/api/Employees/{id}");
        }
        public async Task SaveApiEmployeesTable(EmployeeForApiCall employees)
        {
            await _httpClient.PostAsJsonAsync("/api/Employees", employees);
        }
        public async Task UpdateApiEmployeesTable(EmployeeForApiCall employees)
        {
            await _httpClient.PutAsJsonAsync("/api/Employees", employees);
        }
        public async Task DeleteApiEmployeesTableById(int id)
        {
            await _httpClient.DeleteAsync($"/api/Employees/{id}");
        }
        //EmployeeSecrets Table
        public async Task<List<EmployeeSecretKeyForApiCall>?> GetApiEmployeeSecretKeys()
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeSecretKeyForApiCall>?>("/api/EmployeeSecretKey");
        }
        //Everything for DcVillains Table
        public async Task<List<DcVillainsForApiCall>?> GetApiDcVillainsTable()
        {
            return await _httpClient.GetFromJsonAsync<List<DcVillainsForApiCall>?>("/api/DcVillains");
        }
        public async Task UpdateDcVillainsTable(DcVillainsForApiCall dcVillains)
        {
            await _httpClient.PutAsJsonAsync("/api/DcVillains", dcVillains);
        }
    }
}
