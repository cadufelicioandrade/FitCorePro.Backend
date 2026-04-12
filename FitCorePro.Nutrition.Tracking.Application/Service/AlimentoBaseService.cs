using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Queries;

namespace FitCorePro.Nutrition.Tracking.Application.Service
{
    public class AlimentoBaseService : IAlimentoBaseService
    {
        
        private AlimentoBaseHandlerQuery _handlerQuery;

        public AlimentoBaseService(AlimentoBaseHandlerQuery handlerQuery)
        {
            _handlerQuery = handlerQuery;
        }

        public async Task<List<AlimentoBaseView>> GetAllAsync()
        {
            return await _handlerQuery.GetAllAsync();
        }
    }
}
