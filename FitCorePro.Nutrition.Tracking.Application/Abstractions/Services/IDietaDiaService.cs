using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;

namespace FitCorePro.Nutrition.Tracking.Application.Abstractions.Services
{
    public interface IDietaDiaService
    {
        Task<DietaDiaView> GetAllAsync(string usuarioId, DateOnly dataDieta);
    }
}
