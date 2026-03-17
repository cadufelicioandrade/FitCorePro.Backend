using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.Service;
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao;
using FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Nutrition.Planning.Application.DependencyInjection
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddPlanningApplication(this IServiceCollection services)
        {
            services.AddScoped<GetPlanoSemanalByUsuarioIdHandler>();
            services.AddScoped<PostCriaRefeicaoPlanoSemanalHandler>();
            services.AddScoped<IPlanoSemanalService, PlanoSemanalService>();
            services.AddScoped<IRefeicaoPlanoSemanalService, RefeicaoPlanoSemanalService>();

            return services;
        }
    }
}
