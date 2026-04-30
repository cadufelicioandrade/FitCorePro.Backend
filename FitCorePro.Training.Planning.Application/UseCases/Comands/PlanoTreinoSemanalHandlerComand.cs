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

        public async Task<string> EditHandleAsync(PlanoTreinoSemanalView view,string usuarioId)
        {
            var plano = new PlanoTreinoSemanal(view.Id, view.Ativo, view.Titulo, usuarioId);

            view.TreinosDia.ForEach(t => 
            {
                plano.AdicionarTreinoDia(new TreinoDia(t.Id,t.DiaSemana,t.PlanoTreinoSemanalId));
            });

            var result = await _repo.AtualizarPlanoSemanalAsync(plano);

            return result;
        }

        public async Task<string> CreateHandleAsync(PlanoTreinoSemanalView view, string usuarioId)
        {
            var planoTreinoSemanalId = Guid.NewGuid().ToString();

            var plano = new PlanoTreinoSemanal(planoTreinoSemanalId, true, view.Titulo, usuarioId);

            for (int i = 0; i < 7; i++)
            {
                var treinoDiaId = Guid.NewGuid().ToString();
                plano.AdicionarTreinoDia(new TreinoDia(treinoDiaId, i, planoTreinoSemanalId));
            }

            return await _repo.AdicionarPlanoSemanalAsync(plano);
        }
    }
}
