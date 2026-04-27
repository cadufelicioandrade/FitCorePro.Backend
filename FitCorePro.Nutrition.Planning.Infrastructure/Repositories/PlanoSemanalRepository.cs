using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Repositories
{
    public class PlanoSemanalRepository : IPlanoSemanalRepository
    {
        private readonly PlanningDbContext _context;

        public PlanoSemanalRepository(PlanningDbContext context)
        {
            _context = context;
        }

        public async Task<string> AdicionarPlanoSemanalAsync(PlanoSemanal planoSemanal)
        {
            try
            {
                _context.PlanosSemanal.Add(planoSemanal);
                var result = await _context.SaveChangesAsync();

                if (result > 0) return "Plano semanal incluído com sucesso!";
                return "Falha ao incluir plano semana.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanoSemanal?> GetPlanoByUsuarioIdAsync(string usuarioId)
        {
            try
            {
                var result = await _context.PlanosSemanal.AsNoTracking()
                .Include(p => p.PlanoSemanalDias)
                    .ThenInclude(d => d.RefeicoesPlanoSemanal)
                        .ThenInclude(r => r.AlimentosPlanoSemanais)
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
