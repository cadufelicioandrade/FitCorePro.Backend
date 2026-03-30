using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Queries;

namespace FitCorePro.Nutrition.Tracking.Application.Service
{
    public class DietaDiaService : IDietaDiaService
    {
        private QueryDietaDiaHandler _handle;

        public DietaDiaService(QueryDietaDiaHandler handle)
        {
            _handle = handle;
        }

        public async Task<DietaDiaView> GetAllAsync(string usuarioId, DateTime dataDieta)
        {
            return await _handle.GetAllHandle(new DietaDiaGetAllQuery(usuarioId, dataDieta));
        }
    }
}
