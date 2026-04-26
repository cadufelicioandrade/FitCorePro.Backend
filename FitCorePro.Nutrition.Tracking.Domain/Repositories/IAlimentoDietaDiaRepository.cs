using FitCorePro.Nutrition.Tracking.Domain.Entities;

namespace FitCorePro.Nutrition.Tracking.Domain.Repositories
{
    public interface IAlimentoDietaDiaRepository
    {

        Task<string> EditarAsync(string usuarioId, AlimentoDietaDia alimento);
        Task<string> AdicionarAsync(string usuarioId, AlimentoDietaDia alimento);
        Task<string> ExcluirAsync(string usuarioId, string alimentoDietaDiaId);
    }
}
