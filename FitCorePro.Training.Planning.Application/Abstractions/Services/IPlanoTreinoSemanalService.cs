using FitCorePro.Training.Planning.Application.UseCases.ModelUpdate;
using FitCorePro.Training.Planning.Application.UseCases.ModelView;

namespace FitCorePro.Training.Planning.Application.Abstractions.Services
{
    public interface IPlanoTreinoSemanalService
    {
        Task<PlanoTreinoSemanalView> ObterPlanoTreinoSemanalAsync(string usuarioId);
        Task<string> EditarPlanoTreinoSemanalAsync(PlanoTreinoSemanalUpdate planoTreinoSemanalView, string usuarioId);
        Task<string> AdicionarPlanoTreinoSemanalAsync(PlanoTreinoSemanalView view, string usuarioId);
    }
}
