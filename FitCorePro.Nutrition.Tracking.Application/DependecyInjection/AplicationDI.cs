using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.Service;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Nutrition.Tracking.Application.DependecyInjection
{
    public static class AplicationDI
    {
        public static void AddTrackingApplication(this IServiceCollection service)
        {
            service.AddScoped<DietaDiaGetAllHandler>();
            service.AddScoped<IDietaDiaService , DietaDiaService>();
        }
    }
}
