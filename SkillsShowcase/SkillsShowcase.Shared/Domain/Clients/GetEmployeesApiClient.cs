using SkillsShowcase.Shared.Domain.ApiCallOptions;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SkillsShowcase.Shared.Domain.Clients
{
    public class GetEmployeesApiClient
    {
        private readonly HttpClient _httpClient;

        public GetEmployeesApiClient(ApiClientOptions apiClientOptions) 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }
        //EVERYTHING WITH EMPLOYEE TABLE
        public async Task<List<Employee>?> GetApiEmployeesTable()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>?>("/api/Employees");
        }
        public async Task<Employee?> GetApiEmployeesTableById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee?>($"/api/Employees/{id}");
        }
        public async Task SaveApiEmployeesTable(Employee employees)
        {
            await _httpClient.PostAsJsonAsync("/api/Employees", employees);
        }
        public async Task UpdateApiEmployeesTable(Employee employees)
        {
            await _httpClient.PutAsJsonAsync("/api/Employees", employees);
        }
        public async Task DeleteApiEmployeesTableById(int id)
        {
            await _httpClient.DeleteAsync($"/api/Employees/{id}");
        }
    }
}
