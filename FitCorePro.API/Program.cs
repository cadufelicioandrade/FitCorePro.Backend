using FitCorePro.Nutrition.Planning.Application.DependencyInjection;
using FitCorePro.Nutrition.Planning.Infrastructure.DependencyInjection;
using FitCorePro.Nutrition.Tracking.Application.DependecyInjection;
using FitCorePro.Nutrition.Tracking.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injeção Nutrition Planning
builder.Services.AddPlanningApplication();
builder.Services.AddPlannigInfrastructure(builder.Configuration);

//injeção Nutrition Tracking
builder.Services.AddTrackingApplication();
builder.Services.AddTrackingInfrastructure(builder.Configuration);

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
