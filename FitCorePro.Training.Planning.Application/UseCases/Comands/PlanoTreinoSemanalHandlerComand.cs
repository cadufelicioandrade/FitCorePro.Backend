using FitCorePro.Training.Planning.Application.UseCases.ModelView;
using FitCorePro.Training.Planning.Domain.Entities;
using FitCorePro.Training.Planning.Domain.Repositories;

namespace FitCorePro.Training.Planning.Application.UseCases.Comands
{
    public class PlanoTreinoSemanalHandlerComand
    {
        private readonly IPlanoTreinoSemanalRepository _repo;

        public PlanoTreinoSemanalHandlerComand(IPlanoTreinoSemanalRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> EditHandleAsync(PlanoTreinoSemanalView view)
        {
            var plano = new PlanoTreinoSemanal(view.Id, view.Ativo);

            var result = await _repo.AtualizarPlanoSemanalAsync(plano);

            return result;
        }
    }
}
