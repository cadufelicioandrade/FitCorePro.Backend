using FitCorePro.Nutrition.Planning.Domain.Entities;

namespace FitCorePro.Nutrition.Planning.Domain.Repositories
{
    public interface IRefeicaoPlanoSemanalRepository
    {
        Task<string> AdicionarRefeicaoPlanoSemanalAsync(RefeicaoPlanoSemanal refeicaoPlanoSemanal);
        Task<string> RemoverRefeicaoPlanoSemanalAsync(string refeicaoId);
    }
}
