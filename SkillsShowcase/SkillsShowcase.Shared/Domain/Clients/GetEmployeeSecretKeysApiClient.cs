using SkillsShowcase.Shared.Domain.ApiCallOptions;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SkillsShowcase.Shared.Domain.Clients
{
    public class GetEmployeeSecretKeysApiClient
    {
        private readonly HttpClient _httpClient;
        public GetEmployeeSecretKeysApiClient(ApiClientOptions apiClientOptions) 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }
        public async Task<List<EmployeeSecretKeyForApiCall>?> GetApiEmployeeSecretKeys() 
        { 
            return await _httpClient.GetFromJsonAsync<List<EmployeeSecretKeyForApiCall>?>("/api/EmployeeSecretKey");
        }
    }
}
