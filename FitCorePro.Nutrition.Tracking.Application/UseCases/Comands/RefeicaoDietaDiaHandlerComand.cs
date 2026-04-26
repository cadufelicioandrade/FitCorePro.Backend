using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using System.Linq;

namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Comands
{
    public class RefeicaoDietaDiaHandlerComand
    {
        private readonly IRefeicaoDietaDiaRepository _repo;

        public RefeicaoDietaDiaHandlerComand(IRefeicaoDietaDiaRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> PostHandleAsync(string usuarioId, RefeicaoDietaDiaView view)
        {

            var refeicao = new RefeicaoDietaDia(Guid.NewGuid().ToString(), view.Titulo, view.Ordem, view.DietaDiaId);

            return await _repo.AdicionarRefeicaoDietaDiaAsync(usuarioId, refeicao);
        }

        public async Task<string> DeleteHandleAsync(string usuarioId, string refeicaoDietaDiaId)
        {
            return await _repo.ExcluirRefeicaoPorIdAsync(usuarioId, refeicaoDietaDiaId);
        }

        public async Task<string> UpdateListRefeicoes(string usuarioId,     List<RefeicaoDietaDiaView> list)
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

            return await _repo.AtualizarListRefeicoesAsync(usuarioId, refeicoes);
        }

        public async Task<string> ExcluirRefeicoesPorDataAsync(string usuarioId, DateOnly dataDia)
        {
            return await _repo.ExcluirRefeicoesPorDataAsync(usuarioId, dataDia);
        }
    }
}
