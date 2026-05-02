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
        }

        public async Task<string> atualizarAsync(string usuarioId, AlimentoDietaDia alimento)
        {
            var alimentoUpdate = await _context.AlimentoDietaDia
                                        .FirstOrDefaultAsync(a => a.Id == alimento.Id);

            if (alimentoUpdate is null)
                return "Item inexistente.";

            alimentoUpdate.Id = alimento.Id;
            alimentoUpdate.Nome = alimento.Nome;
            alimentoUpdate.RefeicaoDietaDiaId = alimento.RefeicaoDietaDiaId;
            alimentoUpdate.QuantidadeGramas = alimento.QuantidadeGramas;
            alimentoUpdate.Calorias = alimento.Calorias;
            alimentoUpdate.Carboidratos = alimento.Carboidratos;
            alimentoUpdate.Proteinas = alimento.Proteinas;
            alimentoUpdate.Gorduras = alimento.Gorduras;
            alimentoUpdate.Fibras = alimento.Fibras;

            _context.AlimentoDietaDia.Update(alimentoUpdate);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Alimento editado com sucesso!";

            return "Servidor indisponível, tente novamente mais tarde.";
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
        }
    }
}
