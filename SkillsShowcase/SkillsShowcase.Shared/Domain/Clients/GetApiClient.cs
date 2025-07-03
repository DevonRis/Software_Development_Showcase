using SkillsShowcase.Shared.Domain.ApiCallOptions;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Requests;
using SkillsShowcase.Shared.Domain.RequestsAndResponses.Responses;
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
        //Everything with Guitars Table
        public async Task<List<GuitarsForApiCall>?> GetApiGuitars()
        {
            return await _httpClient.GetFromJsonAsync<List<GuitarsForApiCall>?>("/api/Guitar");
        }
        // Everything with SessionLogs Table
        public async Task<List<SessionLogsForApiCall>?> GetApiSessionLogs()
        {
            return await _httpClient.GetFromJsonAsync<List<SessionLogsForApiCall>?>("/api/SessionLogs");
        }
        //Everything with CarPurchaseInfoLogs Table
        public async Task<List<SoldVsInProcessCarInfoLogsForApiCall>?> GetCarPurchaseInfoLogs()
        {
            return await _httpClient.GetFromJsonAsync<List<SoldVsInProcessCarInfoLogsForApiCall>?>("/api/CarPurchaseInfoLogs");
        }
        //Everything with FirstQuarterRevenue Table
        public async Task<List<FirstQuarterRevenueForApiCall>?> GetFirstQuarterRevenue()
        {
            return await _httpClient.GetFromJsonAsync<List<FirstQuarterRevenueForApiCall>?>("/api/FirstQuarterRevenue");
        }
        //Everything with MarvelVillains Table
        public async Task<List<MarvelVillainsForApiCall>?> GetMarvelConfirmedKills()
        {
            return await _httpClient.GetFromJsonAsync<List<MarvelVillainsForApiCall>?>("/api/MarvelVillains");
        }
        //Everything with NarutoCharacters Table
        public async Task<List<NarutoInfoForApiCall>?> GetNarutoInfo()
        {
            return await _httpClient.GetFromJsonAsync<List<NarutoInfoForApiCall>?>("/api/NarutoCharacters");
        }
        //Everything with GuitarManfactureDetails Table
        public async Task<List<GuitarManufactureDetailsForApiCall>?> GetManufactureDetails()
        {
            return await _httpClient.GetFromJsonAsync<List<GuitarManufactureDetailsForApiCall>?>("/api/GuitarMfDetails");
        }
        //Everything with Assassins Table
        public async Task<List<AssassinsForApiCall>?> GetFromAssassinsTable()
        {
            return await _httpClient.GetFromJsonAsync<List<AssassinsForApiCall>?>("/api/Assassins");
        }
        public async Task SaveInAssassinsTable(AssassinsForApiCall assassins)
        {
            await _httpClient.PostAsJsonAsync("/api/Assassins", assassins);
        }
        public async Task UpdateAssassinsTable(AssassinsForApiCall assassins)
        {
            await _httpClient.PutAsJsonAsync("/api/Assassins", assassins);
        }
        public async Task DeleteAssassinsById(int id)
        {
            await _httpClient.DeleteAsync($"/api/Assassins/{id}");
        }
        //GET ASSASSIN FROM PROCEDURE
        public async Task<List<AssignedAssassinForApiCall>?> GetAssignedAssassinFromApi(GetAssassinRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Assassins/GetAssignedAssassin", request);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            else 
            {
                return await response.Content.ReadFromJsonAsync<List<AssignedAssassinForApiCall>>();
            }
        }
        //GET INVESTMENT RESULTS FROM API
        public async Task<InvestmentResultsResponse?> GetInvestmentResultsFromApi(InvestmentResultsRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Investment/GetInvestmentResults", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InvestmentResultsResponse>();
            }
            else 
            {
                return null;
            }
        }
        //GET EDUCATION DATA FROM API GET METHOD
        public async Task<EducationDataResponse?> GetEducationDataFromApi(EducationDataRequest request)//help me finish
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Education/GetEducationData", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<EducationDataResponse>();
            }
            return null;
        }
    }
}