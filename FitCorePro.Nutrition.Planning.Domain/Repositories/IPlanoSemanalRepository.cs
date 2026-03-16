using FitCorePro.Nutrition.Planning.Domain.Entities;

namespace FitCorePro.Nutrition.Planning.Domain.Repositories
{
    public interface IPlanoSemanalRepository
    {
        Task<PlanoSemanal?> GetPlanoByUsuarioIdAsync(string usuarioId);
    }
}
