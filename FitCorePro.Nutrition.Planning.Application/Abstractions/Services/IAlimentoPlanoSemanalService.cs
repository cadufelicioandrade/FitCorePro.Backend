using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostAlimentos.Request;

namespace FitCorePro.Nutrition.Planning.Application.Abstractions.Services
{
    public interface IAlimentoPlanoSemanalService
    {
        Task<string> AdicionarRangeAlimentoPlanoSemanalAsync(List<AlimentoPlanoSemanalRequest> request);
    }
}
