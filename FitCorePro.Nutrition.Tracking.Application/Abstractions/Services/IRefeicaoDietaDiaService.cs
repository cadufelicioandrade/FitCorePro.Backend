using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Application.Abstractions.Services
{
    public interface IRefeicaoDietaDiaService
    {
        Task<string> AdicionarRefeicaoDietaDiaAsync(RefeicaoDietaDiaView view);
        Task<string> ExcluirRefeicaoDietaDiaAsync(string id);
        Task<RefeicaoDietaDiaView> ObterPorId(string id);
    }
}
