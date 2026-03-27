using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;


namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Queries
{
    public class DietaDiaGetAllHandler
    {
        private readonly IDietaDiaRepository _dietaDiaRepository;

        public DietaDiaGetAllHandler(IDietaDiaRepository ietaDiaRepository)
        {
            _dietaDiaRepository = ietaDiaRepository;
        }

        public async Task<DietaDiaView> GetAllHandle(DietaDiaGetAllQuery query)
        {
            var dietaDia = await _dietaDiaRepository.GetAllAsync(query.usuarioId, query.dataDieta);

            var view = new DietaDiaView(dietaDia.Id, dietaDia.UsuarioId, dietaDia.DataDieta.ToString("yyyy-MM-dd"), dietaDia.CreatedDate.ToString("yyyy-MM-dd"));

            view.RefeicoesDietaDia = dietaDia.RefeicoesDietaDia.Select(y => new RefeicaoDietDiaView
            {
                Id = y.Id,
                DietaDiaId = y.DietaDiaId,
                Ordem = y.Ordem,
                Titulo = y.Titulo,
                CreatedDate = y.CreatedDate.ToString("yyyy-MM-dd"),
                AlimentosDietaDia = y.AlimentosDietaDia.Select(w => new AlimentoDietaDiaView
                {
                    Id = w.Id,
                    Calorias = w.Calorias,
                    Carboidratos = w.Carboidratos,
                    Gorduras = w.Gorduras,
                    Fibras = w.Fibras,
                    Nome = w.Nome,
                    Proteinas = w.Proteinas,
                    QuantidadeGramas = w.QuantidadeGramas,
                    RefeicaoDietaDiaId = w.RefeicaoDietaDiaId,
                    CreatedDate = w.CreatedDate.ToString("yyyy-MM-dd")
                }).ToList()
            }).ToList();

            return view;
        }
}
}
