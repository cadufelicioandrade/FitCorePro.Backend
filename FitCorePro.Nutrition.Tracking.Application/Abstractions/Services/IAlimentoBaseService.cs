using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;

namespace FitCorePro.Nutrition.Tracking.Application.Abstractions.Services
{
    public interface IAlimentoBaseService
    {
        Task<List<AlimentoBaseView>> GetAllAsync();
    }
}
