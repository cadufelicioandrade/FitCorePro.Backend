using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Repositories
{
    public class RefeicaoPlanoSemanalRepository : IRefeicaoPlanoSemanalRepository
    {
        private readonly PlanningDbContext _context;

        public RefeicaoPlanoSemanalRepository(PlanningDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AdicionarRefeicaoPlanoSemanalAsync(RefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            _context.RefeicoesPlanoSemanais.Add(refeicaoPlanoSemanal);

            var resutl = await _context.SaveChangesAsync();

            if(resutl > 0) 
                return true;

            return false;
        }
    }
}
