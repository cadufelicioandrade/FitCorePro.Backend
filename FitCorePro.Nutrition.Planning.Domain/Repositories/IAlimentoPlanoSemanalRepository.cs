using FitCorePro.Nutrition.Planning.Domain.Entities;

namespace FitCorePro.Nutrition.Planning.Domain.Repositories
{
    public interface IAlimentoPlanoSemanalRepository
    {
        Task<string> AdicionarAlimentoPLanoSemanalAsync(List<AlimentoPlanoSemanal> listAlimentos);
    }
}
