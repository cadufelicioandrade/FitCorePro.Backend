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

        public async Task<string> AdicionarRefeicaoDietaDiaAsync(RefeicaoDietaDia refeicao)
        {
            _context.RefeicaoDietaDia.Add(refeicao);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeição adicionada com sucesso!";

            return "Erro de servidor, tente mais tarde.";

            return await Task.FromResult<string>("Refeição adicionada com sucesso!");
        }

        public async Task<string> AtualizarListRefeicoesAsync(List<RefeicaoDietaDia> list)
        {
            _context.RefeicaoDietaDia.UpdateRange(list);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeições atualizadas com sucesso!";

            return "Erro de servidor, tente novamente mais tarde.";

            return await Task.FromResult<string>("Refeição atualizadas com sucesso!");
        }

        public async Task<string> ExcluirRefeicaoPorIdAsync(string id)
        {
            var refeicao = await this.ObterPorIdAsync(id);

            if (refeicao == null)
                return "Refeição não encontrada.";

            _context.RefeicaoDietaDia.Remove(refeicao);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeição excluída com sucesso!";

            return "Erro de servidor, tente novamente mais tarde.";

            return await Task.FromResult<string>("Refeição excluída com sucesso!");
        }

        public async Task<string> ExcluirRefeicoesPorDataAsync(DateTime dataDia)
        {
            var refeicao = await _context.RefeicaoDietaDia.FirstOrDefaultAsync(r => r.CreatedDate == dataDia);

            if (refeicao == null)
                return "Refeição não encontrada.";

            _context.RefeicaoDietaDia.Remove(refeicao);
            var result =  await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeição excluída com sucesso!";

            return "Erro de servicdor, tente novamente mais tarde.";

            return await Task.FromResult<string>("Refeições excluídas com sucesso!");
        }

        public async Task<RefeicaoDietaDia> ObterPorIdAsync(string id)
        {
            var result = await _context.RefeicaoDietaDia.FirstOrDefaultAsync(r => r.Id == id);

            return result;

            return await Task.FromResult<RefeicaoDietaDia>(new RefeicaoDietaDia(id, "teste", 1, "teste-123"));
        }
    }
}
