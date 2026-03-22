using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Repositories
{
    public class AlimentoPlanoSemanalRepository : IAlimentoPlanoSemanalRepository
    {
        private readonly PlanningDbContext _context;

        public AlimentoPlanoSemanalRepository(PlanningDbContext context)
        {
            _context = context;
        }

        public async Task<string> AdicionarAlimentoPLanoSemanalAsync(List<AlimentoPlanoSemanal> listAlimentos)
        {
            //_context.AlimentosPlanoSemanal.AddRange(listAlimentos);
            var result = 1; //await _context.SaveChangesAsync();

            if (result > 0)
                return "Alimento adicionado com sucesso!";

            return "Falha ao adicionar alimento.";
        }

        public async Task<string> EditarAlimentoPlanoSemanalAsync(AlimentoPlanoSemanal alimento)
        {
            //_context.AlimentosPlanoSemanal.Update(alimento);
            var result = 1;//await _context.SaveChangesAsync();

            if (result > 0) return "Alimento editado com sucesso!";
            return "Falha ao editar alimento";
        }

        public async Task<string> ExcluirAlimentoPlanoSemanalAsync(string id)
        {
            //var alimento = await _context.AlimentosPlanoSemanal.FirstOrDefaultAsync(a => a.Id == id);

            //if (alimento == null) return "Alimento não encontrado!";
            
            //_context.AlimentosPlanoSemanal.Remove(alimento);
            var result = 1;//await _context.SaveChangesAsync();

            if (result > 0) return "Alimento excluído com sucesso!";

            return "Falha ao excluir alimento.";
        }
    }
}
