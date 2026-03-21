using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.CreateAlimentos
{
    public class PostAlimentoPlanoSemanalHandler
    {
        private readonly IAlimentoPlanoSemanalRepository _repo;

        public PostAlimentoPlanoSemanalHandler(IAlimentoPlanoSemanalRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> AdicionarRangeHandleAsync(List<AlimentoPlanoSemanalRequest> request)
        {
            var listAlimento = new List<AlimentoPlanoSemanal>();

            request.ForEach(a =>
            {
                var id = Guid.NewGuid().ToString();
                listAlimento.Add(new AlimentoPlanoSemanal(id, a.Nome, a.Gramas, a.RefeicaoPlanoSemanalId));
            });

            return await _repo.AdicionarAlimentoPLanoSemanalAsync(listAlimento);
        }

    }
}
