using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;

namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Comands
{
    public class AlimentoDietaDiaHandlerComand
    {
        private readonly IAlimentoDietaDiaRepository _repo;

        public AlimentoDietaDiaHandlerComand(IAlimentoDietaDiaRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateHandleAsync(string usuarioId, AlimentoDietaDiaView view)
        {
            var id = Guid.NewGuid().ToString();

            var alimento = new AlimentoDietaDia(id, view.Nome, view.RefeicaoDietaDiaId, view.QuantidadeGramas, view.Calorias, view.Carboidratos,view.Proteinas, view.Gorduras, view.Fibras);

            return await _repo.AdicionarAsync(usuarioId, alimento);
        }

        public async Task<string> EditHandleAsync(string usuarioId, AlimentoDietaDiaView view)
        {
            var alimento = new AlimentoDietaDia(view.Id, view.Nome, view.RefeicaoDietaDiaId, view.QuantidadeGramas, view.Calorias, view.Carboidratos, view.Proteinas, view.Gorduras, view.Fibras);

            return await _repo.EditarAsync(usuarioId, alimento);
        }

        internal async Task<string> DeleteHandleAsync(string usuarioId, string alimentoDietaDiaId)
        {
            return await _repo.ExcluirAsync(usuarioId, alimentoDietaDiaId);
        }
    }
}
