using FitCorePro.Training.Planning.Application.UseCases.ModelView;

namespace FitCorePro.Training.Planning.Application.Abstractions.Services
{
    public interface IPlanoTreinoSemanalService
    {
        Task<PlanoTreinoSemanalView> ObterPlanoTreinoSemanalAsync(string usuarioId);
        Task<string> EditarPlanoTreinoSemanalAsync(PlanoTreinoSemanalView planoTreinoSemanalView, string usuarioId);
        Task<string> AdicionarPlanoTreinoSemanalAsync(PlanoTreinoSemanalView view, string usuarioId);
    }
}
