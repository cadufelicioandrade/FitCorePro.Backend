using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;

namespace FitCorePro.Nutrition.Tracking.Application.Abstractions.Services
{
    public interface IRefeicaoDietaDiaService
    {
        Task<string> AdicionarRefeicaoDietaDiaAsync(RefeicaoDietaDiaView view);
        Task<string> AtualizarListaRefeicoes(List<RefeicaoDietaDiaView> list);
        Task<string> ExcluirRefeicaoDietaDiaAsync(string id);
        Task<RefeicaoDietaDiaView> ObterPorId(string id);
    }
}
