using FitCorePro.Training.Planning.Application.Abstractions.Services;
using FitCorePro.Training.Planning.Application.UseCases.Comands;
using FitCorePro.Training.Planning.Application.UseCases.ModelView;

namespace FitCorePro.Training.Planning.Application.Service
{
    public class ExercicioService : IExercicioService
    {

        private readonly ExercicioHandlerComand _handlerComand;

        public ExercicioService(ExercicioHandlerComand handlerComand)
        {
            _handlerComand = handlerComand;
        }

        public async Task<string> AdicionarExercicioAsync(ExercicioView view)
        {
            return await _handlerComand.CreateHandleAsync(view);
        }

        public async Task<string> EditarExercicioAsync(ExercicioView view)
        {
            return await _handlerComand.EditHandleAsync(view);
        }

        public async Task<string> ExcluirExercicioAsync(string exercicioId)
        {
            return await _handlerComand.DeleteHandleAsync(exercicioId);
        }
    }
}
