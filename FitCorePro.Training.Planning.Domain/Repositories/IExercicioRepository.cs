using FitCorePro.Training.Planning.Domain.Entities;

namespace FitCorePro.Training.Planning.Domain.Repositories
{
    public interface IExercicioRepository
    {
        Task<string> AdicionarExercicioAsync(Exercicio exercicio);
        Task<string> EditarExercicioAsync(Exercicio exercicio);
        Task<string> ExcluirExercicio(string exercicioId);
    }
}
