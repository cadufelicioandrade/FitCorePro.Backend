using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.CreateAlimentos;
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostAlimentos.Request;

namespace FitCorePro.Nutrition.Planning.Application.Service
{
    public class AlimentoPlanoSemanalService : IAlimentoPlanoSemanalService
    {
        private PostAlimentoPlanoSemanalHandler _handler;

        public AlimentoPlanoSemanalService(PostAlimentoPlanoSemanalHandler handler)
        {
            _handler = handler;
        }

        public async Task<string> AdicionarRangeAlimentoPlanoSemanalAsync(List<AlimentoPlanoSemanalRequest> request)
        {
            return await _handler.AdicionarRangeHandleAsync(request);
        }
    }
}
