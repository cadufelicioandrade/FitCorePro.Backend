using FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;

namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Queries
{
    public class AlimentoBaseHandlerQuery
    {
        private readonly IAlimentoBaseRepository _repo;

        public AlimentoBaseHandlerQuery(IAlimentoBaseRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<AlimentoBaseView>> GetAllAsync()
        {
            var alimentoBaseList = await _repo.GetAllAsync();

            var listView = new List<AlimentoBaseView>();

            alimentoBaseList.ForEach(a =>
            {
                listView.Add(new AlimentoBaseView(a.Id, a.Nome, a.Gramas, a.Calorias, a.Carboidratos, a.Proteinas, a.Gorduras, a.Fibras));
            });

            return listView;
        }
    }
}
