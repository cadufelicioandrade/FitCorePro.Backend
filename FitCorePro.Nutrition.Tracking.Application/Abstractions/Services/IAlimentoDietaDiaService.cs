using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;

namespace FitCorePro.Nutrition.Tracking.Application.Abstractions.Services
{
    public interface IAlimentoDietaDiaService
    {
        Task<string> EditarAsync(string usuarioId, AlimentoDietaDiaView view);
        Task<string> AdicionarAsync(string usuarioId, AlimentoDietaDiaView view);
        Task<string> ExcluirAsync(string usuarioId, string alimentoDietaDiaId);
    }
}
