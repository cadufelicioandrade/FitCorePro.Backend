using FitCorePro.Training.Planning.Domain.Entities;

namespace FitCorePro.Training.Planning.Domain.Repositories
{
    public interface IPlanoTreinoSemanalRepository
    {
        Task<PlanoTreinoSemanal?> ObterPlanoTreinoSemanalAsync(string usuarioId);
        Task<string> AtualizarPlanoSemanalAsync(PlanoTreinoSemanal planoTreinoSemanal);
        Task<string> AdicionarPlanoSemanalAsync(PlanoTreinoSemanal planoTreinoSemanal);
    }
}
