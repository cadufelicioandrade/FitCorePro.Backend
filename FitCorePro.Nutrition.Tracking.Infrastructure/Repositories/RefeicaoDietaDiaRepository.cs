using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Repositories
{
    public class RefeicaoDietaDiaRepository : IRefeicaoDietaDiaRepository
    {
        public async Task<string> AdicionarRefeicaoDietaDiaAsync(RefeicaoDietaDia refeicao)
        {
            return await Task.FromResult<string>("Refeição adicionada com sucesso!");
        }

        public async Task<string> ExcluirRefeicaoDietaDiaAsync(string id)
        {
            var refeicao = await this.ObterPorIdAsync(id);

            return await Task.FromResult<string>("Refeição excluída com sucesso!");
        }

        public async Task<RefeicaoDietaDia> ObterPorIdAsync(string id)
        {
            return await Task.FromResult<RefeicaoDietaDia>(new RefeicaoDietaDia(id,"teste", 1, "teste-123"));
        }
    }
}
