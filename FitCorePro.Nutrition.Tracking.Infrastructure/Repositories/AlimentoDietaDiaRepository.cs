using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using FitCorePro.Nutrition.Tracking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Repositories
{
    public class AlimentoDietaDiaRepository : IAlimentoDietaDiaRepository
    {

        private TrackingDbContext _context;

        public AlimentoDietaDiaRepository(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<string> AdicionarAsync(string usuarioId, AlimentoDietaDia alimento)
        {
            _context.AlimentoDietaDia.Add(alimento);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Alimento adicionado com sucesso!";

            return "Servidor indisponível, tente novamente mais tarde.";

            //return await Task.FromResult<string>("Alimento adicionado com sucesso!");
        }

        public async Task<string> EditarAsync(string usuarioId, AlimentoDietaDia alimento)
        {
            _context.AlimentoDietaDia.Update(alimento);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Alimento editado com sucesso!";

            return "Servidor indisponível, tente novamente mais tarde.";

            //return await Task.FromResult<string>("Alimento editado com sucesso!");
        }

        public async Task<string> ExcluirAsync(string usuarioId, string alimentoDietaDiaId)
        {
            var alimento = await _context.AlimentoDietaDia.FirstOrDefaultAsync(a => a.Id == alimentoDietaDiaId);

            if (alimento == null)
                return "Alimento não inexistente.";

            _context.AlimentoDietaDia.Remove(alimento);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Alimento excluído com sucesso!";

            return "Servidor indisponível, tente novamente mais tarde.";

            //return await Task.FromResult<string>("Alimento excluído com sucesso!");
        }
    }
}
