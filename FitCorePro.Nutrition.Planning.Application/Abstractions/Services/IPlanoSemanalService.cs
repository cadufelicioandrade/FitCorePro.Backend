using FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response;

namespace FitCorePro.Nutrition.Planning.Application.Abstractions.Services
{
    public interface IPlanoSemanalService
    {
        Task<PlanoSemanalResponse?> GetByUsuarioIdAsync(string usuarioId);
    }
}
