using FitCorePro.Nutrition.Planning.Domain.Entities;

namespace FitCorePro.Nutrition.Planning.Domain.Repositories
{
    public interface IRefeicaoPlanoSemanalRepository
    {
        Task<bool> AdicionarRefeicaoPlanoSemanalAsync(RefeicaoPlanoSemanal refeicaoPlanoSemanal);
    }
}
