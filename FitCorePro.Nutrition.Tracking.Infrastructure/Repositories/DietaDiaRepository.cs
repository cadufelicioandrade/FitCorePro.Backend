using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using FitCorePro.Nutrition.Tracking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Repositories
{
    public class DietaDiaRepository : IDietaDiaRepository
    {
        private TrackingDbContext _context;

        public DietaDiaRepository(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<DietaDia?> GetAllAsync(string usuarioId, DateOnly dataDieta)
        {
            var result = await _context.DietaDia
                .Include(d => d.RefeicoesDietaDia)
                    .ThenInclude(r => r.AlimentosDietaDia)
                .FirstOrDefaultAsync(d => d.UsuarioId == usuarioId && d.DataDieta == dataDieta);

            return result;
        }

    }
}
