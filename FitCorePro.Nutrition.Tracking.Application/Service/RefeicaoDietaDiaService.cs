using FitCorePro.Nutrition.Tracking.Application.Abstractions.Services;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Comands;
using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Application.UseCases.Queries;

namespace FitCorePro.Nutrition.Tracking.Application.Service
{
    public class RefeicaoDietaDiaService : IRefeicaoDietaDiaService
    {
        private ComandRefeicaoDietaDiaHandler _comandHandle;
        private QueryRefeicaoDietaDiaHandler _queryHandle;

        public RefeicaoDietaDiaService(ComandRefeicaoDietaDiaHandler comandHandle, QueryRefeicaoDietaDiaHandler queryHandle)
        {
            _comandHandle = comandHandle;
            _queryHandle = queryHandle;
        }

        public async Task<string> AdicionarRefeicaoDietaDiaAsync(RefeicaoDietaDiaView view)
        {
            return await _comandHandle.PostHandleAsync(view);
        }

        public async Task<string> AtualizarListaRefeicoes(List<RefeicaoDietaDiaView> list)
        {
            return await _comandHandle.UpdateListRefeicoes(list);
        }

        public async Task<string> ExcluirRefeicaoDietaDiaAsync(string id)
        {
            return await _comandHandle.DeleteHandleAsync(id);
        }

        public async Task<string> ExcluirRefeicoesPorDataAsync(DateTime dataDia)
        {
            return await _comandHandle.ExcluirRefeicoesPorDataAsync(dataDia);
        }

        public async Task<RefeicaoDietaDiaView> ObterPorId(string id)
        {
            return await _queryHandle.ObterPorIdAsync(id);
        }
    }
}
