using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Domain.Repositories
{
    public interface IAlimentoBaseRepository
    {
        Task<List<AlimentoBase>> GetAllAsync();
    }
}
