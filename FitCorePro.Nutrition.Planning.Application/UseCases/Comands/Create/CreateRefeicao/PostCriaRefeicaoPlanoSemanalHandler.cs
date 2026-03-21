using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao
{
    public sealed class PostCriaRefeicaoPlanoSemanalHandler
    {
        private readonly IRefeicaoPlanoSemanalRepository _repo;
        public PostCriaRefeicaoPlanoSemanalHandler(IRefeicaoPlanoSemanalRepository refeicaoPlanoSemanal)
        {
            _repo = refeicaoPlanoSemanal;
        }

        public async Task<string> HandleAsync(CriaRefeicaoRequest criaRefeicaoRequest)
        {
            var refeicaoId = Guid.NewGuid().ToString();

            var refeicaoPlanoSemanal = new RefeicaoPlanoSemanal(
                refeicaoId,
                criaRefeicaoRequest.TipoRefeicao,
                0,
                criaRefeicaoRequest.PlanoSemanalDiaId);

            criaRefeicaoRequest.AlimentoPlanoSemanais.ForEach(alimentoResponse =>
            {
                var alimentoId = Guid.NewGuid().ToString();
                var alimento = new AlimentoPlanoSemanal(alimentoId, alimentoResponse.Nome, alimentoResponse.Gramas, refeicaoId);
                refeicaoPlanoSemanal.AdicionarAlimentoPlanoSemanal(alimento);
            });

            //modelar a relação PK e FK para o ef core salvar tudo
            return await _repo.AdicionarRefeicaoPlanoSemanalAsync(refeicaoPlanoSemanal);            
        }
    }
}
