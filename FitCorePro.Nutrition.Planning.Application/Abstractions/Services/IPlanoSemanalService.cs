using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Planning.Application.UseCases.Response;

namespace FitCorePro.Nutrition.Planning.Application.Abstractions.Services
{
    public interface IPlanoSemanalService
    {
        Task<string> AdicionarPlanoSemanalAsync(string usuarioId, PlanoSemanalRequest request);
        Task<PlanoSemanalResponse?> GetByUsuarioIdAsync(string usuarioId);
    }
}
