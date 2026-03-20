
using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request;
using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao
{
    public class DeleteRefeicaoPlanoSemanalHandler
    {
        private IRefeicaoPlanoSemanalRepository _repo;

        public DeleteRefeicaoPlanoSemanalHandler(IRefeicaoPlanoSemanalRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> HandleAsync(string refeicaoId)
        {
            return await _repo.RemoverRefeicaoPlanoSemanalAsync(refeicaoId);
        }
    }
}
