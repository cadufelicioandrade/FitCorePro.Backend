using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Domain.Repositories
{
    public interface IRefeicaoDietaDiaRepository
    {
        Task<string> AdicionarRefeicaoDietaDiaAsync(RefeicaoDietaDia refeicao);
        Task<string> ExcluirRefeicaoDietaDiaAsync(string id);
        Task<RefeicaoDietaDia> ObterPorIdAsync(string id);   
    }
}
