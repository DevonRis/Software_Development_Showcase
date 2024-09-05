using SkillsShowcase.Components;
using SkillsShowcase.Shared.Domain.Data;
using SkillsShowcase.Shared.Domain.IoC;
using Microsoft.AspNetCore.Identity;
using SkillsShowcase.Components.Account;

var builder = WebApplication.CreateBuilder(args);
Secrets.LoadAsync().GetAwaiter().GetResult();
var googleClientID = Secrets.GetLoginSecrets.ClientId;
var googleClientSecret = Secrets.GetLoginSecrets.ClientSecret;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.ApiClientServiceExtenstion(x => x.ApiBaseAddress = builder.Configuration.GetValue<string>("ApiBaseAddress"));



builder.Services.AddAuthentication("SkillsShowcaseUser")
    .AddCookie("SkillsShowcaseUser")
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = googleClientID;
        googleOptions.ClientSecret = googleClientSecret;
    })
    .AddIdentityCookies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapIdentityEndpoints();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
