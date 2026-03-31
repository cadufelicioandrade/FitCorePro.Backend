using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using System.Linq;

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

        public async Task<string> UpdateListRefeicoes(List<RefeicaoDietaDiaView> list)
        {

            var refeicoes = list.Select(refeicaoView =>
            {
                var refeicao = new RefeicaoDietaDia(
                    refeicaoView.Id,
                    refeicaoView.Titulo,
                    refeicaoView.Ordem,
                    refeicaoView.DietaDiaId);

                if (refeicaoView.AlimentosDietaDia.Count > 0)
                {
                    refeicaoView.AlimentosDietaDia.ForEach(a =>
                    {
                        refeicao.AdicionarAlimentoDietaDia(new AlimentoDietaDia(
                            a.Id,
                            a.Nome,
                            a.RefeicaoDietaDiaId,
                            a.QuantidadeGramas,
                            a.Calorias,
                            a.Carboidratos,
                            a.Proteinas,
                            a.Gorduras,
                            a.Fibras));
                    });
                }


                return refeicao;
            }).ToList();

            return await _repo.AtualizarListRefeicoesAsync(refeicoes);
        }
    }
}
