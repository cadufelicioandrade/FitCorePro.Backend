using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using FitCorePro.Nutrition.Tracking.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static void AddTrackingInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDietaDiaRepository, DietaDiaRepository>();
            services.AddScoped<IRefeicaoDietaDiaRepository, RefeicaoDietaDiaRepository>();
            services.AddScoped<IAlimentoDietaDiaRepository, AlimentoDietaDiaRepository>();
        }
    }
}
