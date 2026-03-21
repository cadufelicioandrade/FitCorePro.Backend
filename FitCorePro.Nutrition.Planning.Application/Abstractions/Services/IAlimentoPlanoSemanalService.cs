
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;

namespace FitCorePro.Nutrition.Planning.Application.Abstractions.Services
{
    public interface IAlimentoPlanoSemanalService
    {
        Task<string> AdicionarRangeAlimentoPlanoSemanalAsync(List<AlimentoPlanoSemanalRequest> request);
    }
}
