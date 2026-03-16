using FitCorePro.Nutrition.Planning.Domain.Entities;

namespace FitCorePro.Nutrition.Planning.Domain.Repositories
{
    public interface IRefeicaoPlanoSemanal
    {
        Task<bool> AdicionarRefeicaoPlanoSemanal(RefeicaoPlanoSemanal refeicaoPlanoSemanal);
    }
}
