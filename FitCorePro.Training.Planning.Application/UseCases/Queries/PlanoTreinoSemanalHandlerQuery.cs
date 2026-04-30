using FitCorePro.Training.Planning.Application.UseCases.ModelView;
using FitCorePro.Training.Planning.Domain.Entities;
using FitCorePro.Training.Planning.Domain.Repositories;

namespace FitCorePro.Training.Planning.Application.UseCases.Queries
{
    public class PlanoTreinoSemanalHandlerQuery
    {
        private readonly IPlanoTreinoSemanalRepository _repo;

        public PlanoTreinoSemanalHandlerQuery(IPlanoTreinoSemanalRepository repo)
        {
            _repo = repo;
        }

        public async Task<PlanoTreinoSemanalView> GetHandleAsync(string usuarioId)
        {
            var result = await _repo.ObterPlanoTreinoSemanalAsync(usuarioId);

            if (result is null)
                return null;

            var view = new PlanoTreinoSemanalView
            {
                Id = result.Id,
                Ativo = result.Ativo,
                TreinosDia = result.TreinosDia.Select(treinoDia => new TreinoDiaView
                {
                    Id = treinoDia.Id,
                    DiaSemana = treinoDia.DiaSemana,
                    Exercicios = treinoDia.Exercicios.Select(exercicio => new ExercicioView
                    {
                        Id = exercicio.Id,
                        TipoExercicio = exercicio.TipoExercicio,
                        Serie = exercicio.Serie,
                        Carga = exercicio.Carga
                    }).ToList()
                }).ToList()
            };

            return view;
        }
    }
}
