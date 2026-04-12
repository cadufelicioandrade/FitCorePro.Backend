using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Comands;
using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;

namespace FitCorePro.Nutrition.Tracking.Application.Service
{
    public class AlimentoDietaDiaService : IAlimentoDietaDiaService
    {
        private AlimentoDietaDiaHandlerComand _handler;

        public AlimentoDietaDiaService(AlimentoDietaDiaHandlerComand handler)
        {
            _handler = handler;
        }

        public async Task<string> AdicionarAsync(AlimentoDietaDiaView view)
        {
            return await _handler.CreateHandleAsync(view);
        }

        public async Task<string> EditarAsync(AlimentoDietaDiaView view)
        {
            return await _handler.EditHandleAsync(view);
        }

        public async Task<string> ExcluirAsync(string alimentoDietaDiaId)
        {
            return await _handler.DeleteHandleAsync(alimentoDietaDiaId);
        }
    }
}
