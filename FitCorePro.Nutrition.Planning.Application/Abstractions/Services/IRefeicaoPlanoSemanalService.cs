using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request;

namespace FitCorePro.Nutrition.Planning.Application.Abstractions.Services
{
    public interface IRefeicaoPlanoSemanalService
    {
        Task<string> AdicionarRefeicaoPlanoSemanalAsync(CriaRefeicaoRequest criaRefeicaoRequest);
    }
}
