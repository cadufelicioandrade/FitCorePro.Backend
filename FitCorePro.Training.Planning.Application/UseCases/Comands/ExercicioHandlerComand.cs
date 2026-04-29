using FitCorePro.Training.Planning.Application.UseCases.ModelView;
using FitCorePro.Training.Planning.Domain.Entities;
using FitCorePro.Training.Planning.Domain.Repositories;

namespace FitCorePro.Training.Planning.Application.UseCases.Comands
{
    public class ExercicioHandlerComand
    {
        private readonly IExercicioRepository _repo;

        public ExercicioHandlerComand(IExercicioRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateHandleAsync(ExercicioView view)
        {
            var exercicio = new Exercicio(view.Id, view.TipoExercicio, view.Serie, view.Carga, view.TreinoDiaId);

            return await _repo.AdicionarExercicioAsync(exercicio);
        }

        public async Task<string> EditHandleAsync(ExercicioView view)
        {
            var exercicio = new Exercicio(view.Id, view.TipoExercicio, view.Serie, view.Carga, view.TreinoDiaId);

            return await _repo.EditarExercicioAsync(exercicio);
        }

        public async Task<string> DeleteHandleAsync(string id)
        {
            return await _repo.ExcluirExercicio(id);
        }
    }
}
