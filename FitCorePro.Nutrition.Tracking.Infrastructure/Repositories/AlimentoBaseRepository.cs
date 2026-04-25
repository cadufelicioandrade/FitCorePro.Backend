using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using FitCorePro.Nutrition.Tracking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Repositories
{
    public class AlimentoBaseRepository : IAlimentoBaseRepository
    {
        private TrackingDbContext _context;

        public AlimentoBaseRepository(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlimentoBase>> GetAllAsync()
        {
            var alimentoBase = await _context.AlimentoBase.ToListAsync();


            var resultList = GetMock();
            return await Task.FromResult(resultList);
        }

        private List<AlimentoBase> GetMock()
        {
            var listMock = new List<AlimentoBase>()
            {
                new AlimentoBase("base-00", "RETORNO BACK-END", 100, 130.0, 28.2, 2.7, 0.3, 0.4),
                new AlimentoBase("base-01", "Arroz Branco", 100, 130.0, 28.2, 2.7, 0.3, 0.4),
                new AlimentoBase("base-02", "Feijão Carioca", 100, 76.0, 13.6, 5.0, 0.5, 8.5),
                new AlimentoBase("base-03", "Filé de Frango Grelhado", 100, 165.0, 0.0, 31.0, 3.6, 0.0),
                new AlimentoBase("base-04", "Batata Doce Cozida", 100, 77.0, 18.4, 0.6, 0.1, 2.2),
                new AlimentoBase("base-05", "Ovo Cozido", 100, 155.0, 1.1, 13.0, 11.0, 0.0),
                new AlimentoBase("base-06", "Brócolis Cozido", 100, 35.0, 7.2, 2.5, 0.4, 3.3)
            };

            return listMock;
        }
    }
}
