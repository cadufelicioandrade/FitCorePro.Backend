
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;

namespace FitCorePro.Nutrition.Planning.Application.Abstractions.Services
{
    public interface IAlimentoPlanoSemanalService
    {
        Task<string> AdicionarRangeAlimentoPlanoSemanalAsync(List<AlimentoPlanoSemanalRequest> request);

        Task<string> EditarAlimentoPlanoSemanal(AlimentoPlanoSemanalRequest request);
        Task<string> ExcluirAlimentoPlanoSemanal(string id);
    }
}
