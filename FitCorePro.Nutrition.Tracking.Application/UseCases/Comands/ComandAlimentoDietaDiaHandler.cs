using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;

namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Comands
{
    public class ComandAlimentoDietaDiaHandler
    {
        private readonly IAlimentoDietaDiaRepository _repo;

        public ComandAlimentoDietaDiaHandler(IAlimentoDietaDiaRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateHandleAsync(AlimentoDietaDiaView view)
        {
            var alimento = new AlimentoDietaDia(view.Id, view.Nome, view.RefeicaoDietaDiaId, view.QuantidadeGramas, view.Calorias, view.Carboidratos,view.Proteinas, view.Gorduras, view.Fibras);

            return await _repo.AdicionarAsync(alimento);
        }

        public async Task<string> EditHandleAsync(AlimentoDietaDiaView view)
        {
            var alimento = new AlimentoDietaDia(view.Id, view.Nome, view.RefeicaoDietaDiaId, view.QuantidadeGramas, view.Calorias, view.Carboidratos, view.Proteinas, view.Gorduras, view.Fibras);

            return await _repo.EditarAsync(alimento);
        }
    }
}
