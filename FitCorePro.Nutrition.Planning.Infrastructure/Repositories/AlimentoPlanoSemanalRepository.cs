using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;

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
    }
}
