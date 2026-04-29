using FitCorePro.Training.Planning.Application.UseCases.ModelView;

namespace FitCorePro.Training.Planning.Application.Abstractions.Services
{
    public interface IExercicioService
    {
        Task<string> AdicionarExercicioAsync(ExercicioView view);
        Task<string> EditarExercicioAsync(ExercicioView view);
        Task<string> ExcluirExercicioAsync(string exercicioId);
    }
}
