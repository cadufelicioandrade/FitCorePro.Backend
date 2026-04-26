using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;

namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Queries
{
    public class RefeicaoDietaDiaHandlerQuery
    {
        private readonly IRefeicaoDietaDiaRepository _repo;

        public RefeicaoDietaDiaHandlerQuery(IRefeicaoDietaDiaRepository repo)
        {
            _repo = repo;
        }

        public async Task<RefeicaoDietaDiaView> ObterPorIdAsync(string usuarioId, string id)
        {
            var refeicao = await _repo.ObterPorIdAsync(usuarioId, id);

            var view = new RefeicaoDietaDiaView
            {
                Id = refeicao.Id,
                DietaDiaId = refeicao.DietaDiaId,
                Ordem = refeicao.Ordem,
                Titulo = refeicao.Titulo,
                CreatedDate = refeicao.CreatedDate.ToString("yyyy-MM-dd"),
                AlimentosDietaDia = refeicao.AlimentosDietaDia.Select(x => new AlimentoDietaDiaView(
                    x.Id,
                    x.Nome,
                    x.RefeicaoDietaDiaId,
                    x.QuantidadeGramas,
                    x.Calorias,
                    x.Carboidratos,
                    x.Proteinas,
                    x.Gorduras,
                    x.Fibras,
                    x.CreatedDate.ToString("yyyy-MM-dd")
                    )
                ).ToList()
            };

            return view;
        }
    }
}
