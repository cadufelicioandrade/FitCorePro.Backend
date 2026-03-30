using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;

namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Comands
{
    public class ComandRefeicaoDietaDiaHandler
    {
        private readonly IRefeicaoDietaDiaRepository _repo;

        public ComandRefeicaoDietaDiaHandler(IRefeicaoDietaDiaRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> PostHandleAsync(RefeicaoDietaDiaView view)
        {
            var refeicao = new RefeicaoDietaDia(Guid.NewGuid().ToString(), view.Titulo, view.Ordem, view.DietaDiaId);

            return await _repo.AdicionarRefeicaoDietaDiaAsync(refeicao);
        }

        public async Task<string> DeleteHandleAsync(string refeicaoDietaDiaId)
        {
            return await _repo.ExcluirRefeicaoDietaDiaAsync(refeicaoDietaDiaId);
        }

    }
}
