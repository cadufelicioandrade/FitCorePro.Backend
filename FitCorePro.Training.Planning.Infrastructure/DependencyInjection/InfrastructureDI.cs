using FitCorePro.Training.Planning.Domain.Repositories;
using FitCorePro.Training.Planning.Infrastructure.Persistence;
using FitCorePro.Training.Planning.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Training.Planning.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddTrainingInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TraniningDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPlanoTreinoSemanalRepository, PlanoTreinoSemanalRepository>();
            services.AddScoped<IExercicioRepository, ExercicioRepository>();

            return services;
        }
    }
}
