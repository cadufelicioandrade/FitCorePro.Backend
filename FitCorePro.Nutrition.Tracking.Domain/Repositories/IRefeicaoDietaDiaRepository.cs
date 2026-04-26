using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Domain.Repositories
{
    public interface IRefeicaoDietaDiaRepository
    {
        Task<string> AdicionarRefeicaoDietaDiaAsync(string usuárioId, RefeicaoDietaDia refeicao);
        Task<string> ExcluirRefeicaoPorIdAsync(string usuárioId, string id);
        Task<RefeicaoDietaDia> ObterPorIdAsync(string usuárioId, string id);
        Task<string> AtualizarListRefeicoesAsync(string usuárioId, List<RefeicaoDietaDia> list);
        Task<string> ExcluirRefeicoesPorDataAsync(string usuárioId, DateOnly dataDia);
    }
}
