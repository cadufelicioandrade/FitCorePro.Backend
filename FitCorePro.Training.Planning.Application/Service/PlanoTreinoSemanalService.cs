using FitCorePro.Training.Planning.Application.Abstractions.Services;
using FitCorePro.Training.Planning.Application.UseCases.Comands;
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

        public async Task<string> EditarPlanoTreinoSemanalAsync(PlanoTreinoSemanalView planoTreinoSemanalView)
        {
            return await _handlerComand.EditHandleAsync(planoTreinoSemanalView);
        }

        public async Task<PlanoTreinoSemanalView> ObterPlanoTreinoSemanalAsync()
        {
            return await _handlerQuery.GetHandleAsync();
        }
    }
}
