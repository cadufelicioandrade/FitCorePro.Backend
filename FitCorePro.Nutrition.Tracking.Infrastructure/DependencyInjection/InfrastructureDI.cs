using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using FitCorePro.Nutrition.Tracking.Infrastructure.Persistence;
using FitCorePro.Nutrition.Tracking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static void AddTrackingInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrackingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDietaDiaRepository, DietaDiaRepository>();
            services.AddScoped<IRefeicaoDietaDiaRepository, RefeicaoDietaDiaRepository>();
            services.AddScoped<IAlimentoDietaDiaRepository, AlimentoDietaDiaRepository>();
            services.AddScoped<IAlimentoBaseRepository, AlimentoBaseRepository>();
        }
    }
}
