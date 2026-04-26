using FitCorePro.Nutrition.Planning.Application.Abstractions.Services;
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao;
using FitCorePro.Nutrition.Planning.Application.UseCases.Request;

namespace FitCorePro.Nutrition.Planning.Application.Service
{
    public class RefeicaoPlanoSemanalService : IRefeicaoPlanoSemanalService
    {
        private PostCriaRefeicaoPlanoSemanalHandler _postHandler;
        private DeleteRefeicaoPlanoSemanalHandler _deleteHandler;

        public RefeicaoPlanoSemanalService(PostCriaRefeicaoPlanoSemanalHandler handler, DeleteRefeicaoPlanoSemanalHandler deleteHandler)
        {
            _postHandler = handler;
            _deleteHandler = deleteHandler;
        }

        public async Task<string> AdicionarRefeicaoPlanoSemanalAsync(string usuarioId, CriaRefeicaoRequest criaRefeicaoRequest)
        {
            var result = await _postHandler.HandleAsync(usuarioId, criaRefeicaoRequest);
            return result;
        }

        public async Task<string> RemoverRefeicaoPlanoSemanalAsync(string usuarioId, string refeicaoId)
        {
            return await _deleteHandler.HandleAsync(usuarioId, refeicaoId);
        }
    }
}
