using FitCorePro.Training.Planning.Application.Abstractions.Services;
using FitCorePro.Training.Planning.Application.Service;
using FitCorePro.Training.Planning.Application.UseCases.Comands;
using FitCorePro.Training.Planning.Application.UseCases.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Training.Planning.Application.DependencyInjection
{
    public static class ApplicatinDI
    {
        public static IServiceCollection AddTrainingApplication(this  IServiceCollection services)
        {
            services.AddScoped<PlanoTreinoSemanalHandlerComand>();
            services.AddScoped<ExercicioHandlerComand>();
            services.AddScoped<PlanoTreinoSemanalHandlerQuery>();

            services.AddScoped<IPlanoTreinoSemanalService, PlanoTreinoSemanalService>();
            services.AddScoped<IExercicioService, ExercicioService>();

            return services;
        }
    }
}
