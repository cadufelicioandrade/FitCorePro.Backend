using FitCorePro.Nutrition.Planning.Application.DependencyInjection;
using FitCorePro.Nutrition.Planning.Infrastructure.DependencyInjection;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlanningDbContext>(options =>
options.UseInMemoryDatabase("NOME_BANCO_DADOS"));


builder.Services.AddPlanningApplication();
builder.Services.AddPlannigInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
