using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SkillsShowcase.Shared.Domain.ApiCallOptions;
using SkillsShowcase.Shared.Domain.Clients;
using System;

namespace SkillsShowcase.Shared.Domain.IoC
{
    public static class ServiceCollectionExtensionForAPP
    {
        public static void ApiClientServiceExtenstion(this IServiceCollection services, Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new GetApiClient(options);
            });
        }
    }
}
