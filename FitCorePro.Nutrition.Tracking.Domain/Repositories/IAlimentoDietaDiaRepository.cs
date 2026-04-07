using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Domain.Repositories
{
    public interface IAlimentoDietaDiaRepository
    {

        Task<string> EditarAsync(AlimentoDietaDia alimento);
        Task<string> AdicionarAsync(AlimentoDietaDia alimento);
    }
}
