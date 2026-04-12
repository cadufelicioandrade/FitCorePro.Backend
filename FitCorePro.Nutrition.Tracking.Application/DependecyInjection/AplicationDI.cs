using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.Service;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Comands;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Nutrition.Tracking.Application.DependecyInjection
{
    public static class AplicationDI
    {
        public static void AddTrackingApplication(this IServiceCollection service)
        {
            service.AddScoped<DietaDiaHandlerQuery>();
            service.AddScoped<RefeicaoDietaDiaHandlerQuery>();
            service.AddScoped<RefeicaoDietaDiaHandlerComand>();
            service.AddScoped<AlimentoDietaDiaHandlerComand>();
            service.AddScoped<AlimentoBaseHandlerQuery>();
            service.AddScoped<IDietaDiaService , DietaDiaService>();
            service.AddScoped<IRefeicaoDietaDiaService, RefeicaoDietaDiaService>();
            service.AddScoped<IAlimentoDietaDiaService, AlimentoDietaDiaService>();
            service.AddScoped<IAlimentoBaseService, AlimentoBaseService>();
        }
    }
}
