using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;


namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Queries
{
    public class DietaDiaHandlerQuery
    {
        private readonly IDietaDiaRepository _dietaDiaRepository;

        public DietaDiaHandlerQuery(IDietaDiaRepository ietaDiaRepository)
        {
            _dietaDiaRepository = ietaDiaRepository;
        }

        public async Task<DietaDiaView> GetAllHandle(DietaDiaGetAllQuery query)
        {
            var dietaDia = await _dietaDiaRepository.GetAllAsync(query.usuarioId, query.dataDieta);

            var view = new DietaDiaView(dietaDia.Id, dietaDia.UsuarioId, dietaDia.DataDieta.ToString("yyyy-MM-dd"), dietaDia.CreatedDate.ToString("yyyy-MM-dd"));

            view.RefeicoesDietaDia = dietaDia.RefeicoesDietaDia.Select(y => new RefeicaoDietaDiaView
            {
                Id = y.Id,
                DietaDiaId = y.DietaDiaId,
                Ordem = y.Ordem,
                Titulo = y.Titulo,
                CreatedDate = y.CreatedDate.ToString("yyyy-MM-dd"),
                AlimentosDietaDia = y.AlimentosDietaDia.Select(w => new AlimentoDietaDiaView(
                    w.Id,
                    w.Nome,
                    w.RefeicaoDietaDiaId,
                    w.QuantidadeGramas,
                    w.Calorias,
                    w.Carboidratos,
                    w.Proteinas,
                    w.Gorduras,
                    w.Fibras,
                    w.CreatedDate.ToString("yyyy-MM-dd"))).ToList()
            }).ToList();

            return view;
        }
    }
}
