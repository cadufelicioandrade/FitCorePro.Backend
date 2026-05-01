using FitCorePro.Training.Planning.Domain.Entities;
using FitCorePro.Training.Planning.Domain.Repositories;
using FitCorePro.Training.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Training.Planning.Infrastructure.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        public TraniningDbContext _context;

        public ExercicioRepository(TraniningDbContext context)
        {
            _context = context;
        }

        public async Task<string> AdicionarExercicioAsync(Exercicio exercicio)
        {
            _context.Exercicio.Add(exercicio);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Exercício adicionado com sucesso!";

            return "Não foi possível realizar a operção, tente novamente mais tarde.";
        }

        public async Task<string> EditarExercicioAsync(Exercicio exercicio)
        {
            _context.Exercicio.Update(exercicio);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Exercício editado com sucesso!";

            return "Não foi possível realizar a operção, tente novamente mais tarde.";
        }

        public async Task<string> ExcluirExercicio(string exercicioId)
        {
            var exercio = await _context.Exercicio.FirstOrDefaultAsync(e => e.Id == exercicioId);

            if (exercio == null)
                return "Exercício não encontrado.";

            _context.Exercicio.Remove(exercio);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Exercício excluído com sucesso!";

            return "Não foi possível realizar a operção, tente novamente mais tarde.";
        }
    }
}
