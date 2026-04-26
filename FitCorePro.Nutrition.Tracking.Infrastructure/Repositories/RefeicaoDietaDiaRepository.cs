using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using FitCorePro.Nutrition.Tracking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Repositories
{
    public class RefeicaoDietaDiaRepository : IRefeicaoDietaDiaRepository
    {
        private TrackingDbContext _context;

        public RefeicaoDietaDiaRepository(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<string> AdicionarRefeicaoDietaDiaAsync(string usuarioId, RefeicaoDietaDia refeicao)
        {
            if (String.IsNullOrEmpty(refeicao.DietaDiaId))
            {
                var dietaDiaId = Guid.NewGuid().ToString();
                var dietaDia = new DietaDia(
                                    dietaDiaId,
                                    usuarioId,
                                    DateOnly.FromDateTime(DateTime.Now));

                _context.DietaDia.Add(dietaDia);
                await _context.SaveChangesAsync();
                refeicao.DietaDiaId = dietaDiaId;
            }

            _context.RefeicaoDietaDia.Add(refeicao);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeição adicionada com sucesso!";

            return "Erro de servidor, tente mais tarde.";

        }

        public async Task<string> AtualizarListRefeicoesAsync(string usuarioId, List<RefeicaoDietaDia> list)
        {
            _context.RefeicaoDietaDia.UpdateRange(list);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeições atualizadas com sucesso!";

            return "Erro de servidor, tente novamente mais tarde.";
        }

        public async Task<string> ExcluirRefeicaoPorIdAsync(string usuarioId, string id)
        {
            var refeicao = await this.ObterPorIdAsync(usuarioId, id);

            if (refeicao == null)
                return "Refeição não encontrada.";

            _context.RefeicaoDietaDia.Remove(refeicao);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeição excluída com sucesso!";

            return "Erro de servidor, tente novamente mais tarde.";

        }

        public async Task<string> ExcluirRefeicoesPorDataAsync(string usuarioId, DateOnly dataDia)
        {
            var dietaDia = await _context.DietaDia
                .Include(d => d.RefeicoesDietaDia)
                .FirstOrDefaultAsync(d => d.UsuarioId == usuarioId && d.DataDieta == dataDia);

            if (dietaDia == null || !dietaDia.RefeicoesDietaDia.Any())
                return "Nenhuma refeição encontrada para este dia.";

            _context.RefeicaoDietaDia.RemoveRange(dietaDia.RefeicoesDietaDia);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeições excluídas com sucesso!";

            return "Erro de servidor, tente novamente mais tarde.";
        }

        public async Task<RefeicaoDietaDia> ObterPorIdAsync(string usuarioId, string id)
        {
            var result = await _context.RefeicaoDietaDia.FirstOrDefaultAsync(r => r.Id == id);

            return result;

        }
    }
}
