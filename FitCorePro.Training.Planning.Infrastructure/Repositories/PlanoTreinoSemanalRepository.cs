using FitCorePro.Training.Planning.Domain.Entities;
using FitCorePro.Training.Planning.Domain.Repositories;
using FitCorePro.Training.Planning.Infrastructure.Persistence;

namespace FitCorePro.Training.Planning.Infrastructure.Repositories
{
    public class PlanoTreinoSemanalRepository : IPlanoTreinoSemanalRepository
    {
        public TraniningDbContext _contex;

        public PlanoTreinoSemanalRepository(TraniningDbContext contex)
        {
            _contex = contex;
        }

        public Task<string> AtualizarPlanoSemanalAsync(PlanoTreinoSemanal planoTreinoSemanal)
        {
            throw new NotImplementedException();
        }

        public Task<PlanoTreinoSemanal> ObterPlanoTreinoSemanalAsync()
        {
            throw new NotImplementedException();
        }
    }
}
