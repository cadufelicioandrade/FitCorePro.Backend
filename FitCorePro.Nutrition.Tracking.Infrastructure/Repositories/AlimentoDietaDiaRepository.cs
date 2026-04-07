using FitCorePro.Nutrition.Tracking.Domain.Entities;
using FitCorePro.Nutrition.Tracking.Domain.Repositories;

namespace FitCorePro.Nutrition.Tracking.Infrastructure.Repositories
{
    public class AlimentoDietaDiaRepository : IAlimentoDietaDiaRepository
    {
        public async Task<string> AdicionarAsync(AlimentoDietaDia alimento)
        {
            return await Task.FromResult<string>("Alimento adicionado com sucesso!");
        }

        public async Task<string> EditarAsync(AlimentoDietaDia alimento)
        {
            return await Task.FromResult<string>("Alimento Editado com sucesso!");
        }
    }
}
