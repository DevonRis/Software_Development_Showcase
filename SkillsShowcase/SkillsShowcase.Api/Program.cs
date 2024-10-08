using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Api.Models.Data;
using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

//builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GuitarService>();
builder.Services.AddScoped<GuitarRepository>();
builder.Services.AddScoped<CarInfoLogsService>();
builder.Services.AddScoped<CarInfoLogsRepository>();
builder.Services.AddScoped<FirstQuarterRevenueService>();
builder.Services.AddScoped<FirstQuarterRevenueRepository>();
builder.Services.AddScoped<MarvelVillainsService>();
builder.Services.AddScoped<MarvelVillainsRepository>();
builder.Services.AddScoped<FavoriteMusiciansService>();
builder.Services.AddScoped<FavoriteMusiciansRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("Open");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
