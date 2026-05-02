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
            var exercicioUpdate = await _context.Exercicio.FirstOrDefaultAsync(e => e.Id == exercicio.Id);


            if (exercicioUpdate is null)
                return "Item não inexistente.";

            exercicioUpdate.Id = exercicio.Id;
            exercicioUpdate.TipoExercicio = exercicio.TipoExercicio;
            exercicioUpdate.Serie = exercicio.Serie;
            exercicioUpdate.Carga = exercicio.Carga;
            exercicioUpdate.TreinoDiaId = exercicio.TreinoDiaId;

            _context.Exercicio.Update(exercicioUpdate);
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
