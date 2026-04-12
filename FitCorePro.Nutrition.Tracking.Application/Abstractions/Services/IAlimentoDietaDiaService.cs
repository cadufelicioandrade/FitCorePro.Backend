using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;

namespace FitCorePro.Nutrition.Tracking.Application.Abstractions.Services
{
    public interface IAlimentoDietaDiaService
    {
        Task<string> EditarAsync(AlimentoDietaDiaView view);
        Task<string> AdicionarAsync(AlimentoDietaDiaView view);
        Task<string> ExcluirAsync(string alimentoDietaDiaId);
    }
}
