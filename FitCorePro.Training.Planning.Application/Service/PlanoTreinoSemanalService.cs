using FitCorePro.Training.Planning.Application.Abstractions.Services;
using FitCorePro.Training.Planning.Application.UseCases.Comands;
using FitCorePro.Training.Planning.Application.UseCases.ModelUpdate;
using FitCorePro.Training.Planning.Application.UseCases.ModelView;
using FitCorePro.Training.Planning.Application.UseCases.Queries;

namespace FitCorePro.Training.Planning.Application.Service
{
    public class PlanoTreinoSemanalService : IPlanoTreinoSemanalService
    {
        private readonly PlanoTreinoSemanalHandlerComand _handlerComand;
        private readonly PlanoTreinoSemanalHandlerQuery _handlerQuery;

        public PlanoTreinoSemanalService(PlanoTreinoSemanalHandlerComand handlerComand, PlanoTreinoSemanalHandlerQuery handlerQuery)
        {
            _handlerComand = handlerComand;
            _handlerQuery = handlerQuery;
        }

        public async Task<string> AdicionarPlanoTreinoSemanalAsync(PlanoTreinoSemanalView view, string usuarioId)
        {
            return await _handlerComand.CreateHandleAsync(view, usuarioId);
        }

        public async Task<string> EditarPlanoTreinoSemanalAsync(PlanoTreinoSemanalUpdate planoTreinoSemanalView, string usuarioId)
        {
            return await _handlerComand.EditHandleAsync(planoTreinoSemanalView, usuarioId);
        }

        public async Task<PlanoTreinoSemanalView> ObterPlanoTreinoSemanalAsync(string usuarioId)
        {
            return await _handlerQuery.GetHandleAsync(usuarioId);
        }
    }
}
