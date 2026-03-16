using FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request;
using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao
{
    public sealed class PostCriaRefeicaoPlanoSemanalHandler
    {
        private readonly IRefeicaoPlanoSemanal _repo;
        public PostCriaRefeicaoPlanoSemanalHandler(IRefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            _repo = refeicaoPlanoSemanal;
        }

        public async Task<string> Handle(CriaRefeicaoRequest criaRefeicaoRequest)
        {

            var refeicaoPlanoSemanal = new RefeicaoPlanoSemanal(
                "",
                criaRefeicaoRequest.TipoRefeicao,
                0,
                criaRefeicaoRequest.PlanoSemanalDiaId,
                DateTime.Now);

            criaRefeicaoRequest.AlimentoPlanoSemanais.ForEach(alimentoResponse =>
            {
                var alimento = new AlimentoPlanoSemanal("", alimentoResponse.Nome, alimentoResponse.Gramas, "", DateTime.Now);
                refeicaoPlanoSemanal.AdicionarAlimentoPlanoSemanal(alimento);
            });

            //modelar a relação PK e FK para o ef core salvar tudo
            await _repo.AdicionarRefeicaoPlanoSemanal(refeicaoPlanoSemanal);

            return "";
        }
    }
}
