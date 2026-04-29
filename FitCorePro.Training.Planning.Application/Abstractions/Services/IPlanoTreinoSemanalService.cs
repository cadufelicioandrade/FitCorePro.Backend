using FitCorePro.Training.Planning.Application.UseCases.ModelView;

namespace FitCorePro.Training.Planning.Application.Abstractions.Services
{
    public interface IPlanoTreinoSemanalService
    {
        Task<PlanoTreinoSemanalView> ObterPlanoTreinoSemanalAsync();
        Task<string> EditarPlanoTreinoSemanalAsync(PlanoTreinoSemanalView planoTreinoSemanalView);
    }
}
