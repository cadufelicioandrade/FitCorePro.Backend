using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Domain.Repositories
{
    public interface IRefeicaoDietaDiaRepository
    {
        Task<string> AdicionarRefeicaoDietaDiaAsync(RefeicaoDietaDia refeicao);
        Task<string> ExcluirRefeicaoPorIdAsync(string id);
        Task<RefeicaoDietaDia> ObterPorIdAsync(string id);
        Task<string> AtualizarListRefeicoesAsync(List<RefeicaoDietaDia> list);
        Task<string> ExcluirRefeicoesPorDataAsync(DateTime dataDia);
    }
}
