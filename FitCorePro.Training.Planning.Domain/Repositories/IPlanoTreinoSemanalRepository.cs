using FitCorePro.Training.Planning.Domain.Entities;

namespace FitCorePro.Training.Planning.Domain.Repositories
{
    public interface IPlanoTreinoSemanalRepository
    {
        Task<PlanoTreinoSemanal> ObterPlanoTreinoSemanalAsync();
        Task<string> AtualizarPlanoSemanalAsync(PlanoTreinoSemanal planoTreinoSemanal);
    }
}
