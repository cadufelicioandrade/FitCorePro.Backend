using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Nutrition.Planning.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddPlannigInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPlanoSemanalRepository, PlanoSemanalRepository>();
            services.AddScoped<IRefeicaoPlanoSemanalRepository, RefeicaoPlanoSemanalRepository>();
            services.AddScoped<IAlimentoPlanoSemanalRepository, AlimentoPlanoSemanalRepository>();
            return services;
        }
    }
}
