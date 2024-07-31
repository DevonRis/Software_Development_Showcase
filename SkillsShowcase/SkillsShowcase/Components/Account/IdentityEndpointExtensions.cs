using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SkillsShowcase.Components.Account
{
    internal static class IdentityEndpointExtensions
    {
        public static IEndpointConventionBuilder MapIdentityEndpoints(this IEndpointRouteBuilder endpoints) 
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var accountGroup = endpoints.MapGroup("/Account");

            accountGroup.MapPost("/Logout", async (HttpContext context, [FromForm] string returnUrl) =>
            {
                await context.SignOutAsync("SkillsShowcaseUser");
                return TypedResults.LocalRedirect($"/");
            });

            accountGroup.MapPost("/PerformGoogleLogin", async (HttpContext context, [FromForm] string returnUrl) =>
            {
                // a more generic implementation would pass the provider as well but we know it's Google here
                string provider = "Google";

                var properties = new AuthenticationProperties { RedirectUri = returnUrl };

                // Sign out any existing user
                await context.SignOutAsync("SkillsShowcaseUser");

                return TypedResults.Challenge(properties, [provider]);
            });

            return accountGroup;
        }
    }
}
