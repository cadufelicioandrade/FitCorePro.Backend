using FitCorePro.Training.Planning.Domain.Entities;
using FitCorePro.Training.Planning.Domain.Repositories;
using FitCorePro.Training.Planning.Infrastructure.Persistence;

namespace FitCorePro.Training.Planning.Infrastructure.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        public TraniningDbContext _context;

        public ExercicioRepository(TraniningDbContext context)
        {
            _context = context;
        }

        public Task<string> AdicionarExercicioAsync(Exercicio exercicio)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditarExercicioAsync(Exercicio exercicio)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExcluirExercicio(string exercicioId)
        {
            throw new NotImplementedException();
        }
    }
}
