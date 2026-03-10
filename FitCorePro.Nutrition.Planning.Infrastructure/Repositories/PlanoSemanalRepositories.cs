using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Repositories
{
    public class PlanoSemanalRepositories : IPlanoSemanalRepository
    {
        private readonly PlanningDbContext _context;

        public PlanoSemanalRepositories(PlanningDbContext context)
        {
            _context = context;
        }

        public async Task<PlanoSemanal?> GetPlanoByUsuarioIdAsync(string usuarioId)
        {
            return await _context.PlanosSemanais
                .AsNoTracking()
                .Include(p => p.PlanoSemanalDias)
                    .ThenInclude(d => d.Refeicoes)
                        .ThenInclude(r => r.RefeicaoAlimentos)
                            .ThenInclude(ra => ra.Alimento)
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);
        }
    }
}
