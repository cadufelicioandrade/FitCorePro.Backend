using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Domain.Repositories
{
    public interface IDietaDiaRepository
    {
        Task<DietaDia> GetAllAsync(string usuarioId, DateOnly dataDieta);
    }
}
