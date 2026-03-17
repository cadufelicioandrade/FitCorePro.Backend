using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao;
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request;

namespace FitCorePro.Nutrition.Planning.Application.Service
{
    public class RefeicaoPlanoSemanalService : IRefeicaoPlanoSemanalService
    {
        private PostCriaRefeicaoPlanoSemanalHandler _handler;

        public RefeicaoPlanoSemanalService(PostCriaRefeicaoPlanoSemanalHandler handler)
        {
            _handler = handler;
        }

        public async Task<string> AdicionarRefeicaoPlanoSemanalAsync(CriaRefeicaoRequest criaRefeicaoRequest)
        {
            var result = await _handler.HandleAsync(criaRefeicaoRequest);
            return result;
        }
    }
}
