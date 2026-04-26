using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;

namespace FitCorePro.Nutrition.Tracking.Application.Abstractions.Services
{
    public interface IRefeicaoDietaDiaService
    {
        Task<string> AdicionarRefeicaoDietaDiaAsync(string usuarioId, RefeicaoDietaDiaView view);
        Task<string> AtualizarListaRefeicoes(string usuarioId, List<RefeicaoDietaDiaView> list);
        Task<string> ExcluirRefeicaoDietaDiaAsync(string usuarioId, string id);
        Task<RefeicaoDietaDiaView> ObterPorId(string usuarioId, string id);
        Task<string> ExcluirRefeicoesPorDataAsync(string usuarioId, DateOnly dataDia);
    }
}
