using FitCorePro.Training.Planning.Application.UseCases.ModelUpdate;
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

        public async Task<string> EditHandleAsync(PlanoTreinoSemanalUpdate view,string usuarioId)
        {
            var plano = new PlanoTreinoSemanal(view.Id, view.Ativo, view.Titulo, usuarioId);

            var result = await _repo.AtualizarPlanoSemanalAsync(plano);

            return result;
        }

        public async Task<string> CreateHandleAsync(PlanoTreinoSemanalView view, string usuarioId)
        {
            var planoTreinoSemanalId = Guid.NewGuid().ToString();

            var plano = new PlanoTreinoSemanal(
                planoTreinoSemanalId,
                true,
                view.Titulo,
                usuarioId
            );

            var treinosDiaView = view.TreinosDia ?? new List<TreinoDiaView>();

            for (int diaSemana = 1; diaSemana <= 7; diaSemana++)
            {
                var treinoDiaView = treinosDiaView
                    .FirstOrDefault(x => x.DiaSemana == diaSemana);

                var treinoDiaId = Guid.NewGuid().ToString();

                var treinoDia = new TreinoDia(
                    treinoDiaId,
                    diaSemana,
                    planoTreinoSemanalId
                );

                if (treinoDiaView?.Exercicios != null && treinoDiaView.Exercicios.Any())
                {
                    foreach (var exercicioView in treinoDiaView.Exercicios)
                    {
                        var exercicio = new Exercicio(
                            Guid.NewGuid().ToString(),
                            exercicioView.TipoExercicio,
                            exercicioView.Series,
                            exercicioView.Carga,
                            treinoDiaId
                        );

                        treinoDia.AdicionarExercicio(exercicio);
                    }
                }

                plano.AdicionarTreinoDia(treinoDia);
            }

            return await _repo.AdicionarPlanoSemanalAsync(plano);
        }
    }
}
