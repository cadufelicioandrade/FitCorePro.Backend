using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;
using System.Numerics;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Repositories
{
    public class DietaDiaRepository : IDietaDiaRepository
    {
        public async Task<DietaDia> GetAllAsync(string usuarioId, DateTime dataDieta)
        {
            return await Task.FromResult<DietaDia?>(GetMock(dataDieta));
        }


        private DietaDia GetMock(DateTime dataDieta)
        {
            var dietaDia = new DietaDia("dieta-dia-123", "user123", DateTime.Now);

            var refeicao1 = new RefeicaoDietaDia("refeicao-01", "Café Da Manhã", 1, "dieta-dia-123");
            var refeicao2 = new RefeicaoDietaDia("refeicao-02", "Almoço", 1, "dieta-dia-123");
            var refeicao3 = new RefeicaoDietaDia("refeicao-03", "Jantar", 1, "dieta-dia-123");

            var alimento1 = new AlimentoDietaDia(Guid.NewGuid().ToString(), "Banana", "refeicao-01", 200, 23, 12, 13, 24, 56);
            var alimento2 = new AlimentoDietaDia(Guid.NewGuid().ToString(), "Ovos", "refeicao-01", 10, 12, 23, 98, 87, 23);

            var alimento3 = new AlimentoDietaDia(Guid.NewGuid().ToString(), "Arroz", "refeicao-02", 200, 23, 12, 13, 24, 56);
            var alimento4 = new AlimentoDietaDia(Guid.NewGuid().ToString(), "File de frango", "refeicao-02", 10, 12, 23, 98, 87, 23);

            var alimento5 = new AlimentoDietaDia(Guid.NewGuid().ToString(), "Batata doce", "refeicao-03", 200, 23, 12, 13, 24, 56);
            var alimento6 = new AlimentoDietaDia(Guid.NewGuid().ToString(), "Carne", "refeicao-03", 10, 12, 23, 98, 87, 23);

            refeicao1.AdicionarAlimentoDietaDia(alimento1);
            refeicao1.AdicionarAlimentoDietaDia(alimento2);

            refeicao2.AdicionarAlimentoDietaDia(alimento3);
            refeicao2.AdicionarAlimentoDietaDia(alimento4);

            refeicao3.AdicionarAlimentoDietaDia(alimento5);
            refeicao3.AdicionarAlimentoDietaDia(alimento6);

            dietaDia.AdicionarRefeicaoDietaDia(refeicao1);
            dietaDia.AdicionarRefeicaoDietaDia(refeicao2);
            dietaDia.AdicionarRefeicaoDietaDia(refeicao3);

            return dietaDia;

        }

    }
}
