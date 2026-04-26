using FitCorePro.Nutrition.Planning.Application.UseCases.Request;

namespace FitCorePro.Nutrition.Planning.Application.Abstractions.Services
{
    public interface IRefeicaoPlanoSemanalService
    {
        Task<string> AdicionarRefeicaoPlanoSemanalAsync(string usuarioId, CriaRefeicaoRequest criaRefeicaoRequest);
        Task<string> RemoverRefeicaoPlanoSemanalAsync(string usuarioId, string refeicaoId);
    }
}
