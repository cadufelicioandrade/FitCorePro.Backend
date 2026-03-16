using FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request
{
    public class CriaRefeicaoRequest
    {
        public string PlanoSemanalDiaId { get; set; }
        public int DiaSemana { get; set; }
        public string TipoRefeicao { get; set; }
        public List<AlimentoPlanoSemanalResponse> AlimentoPlanoSemanais { get; set; }
    }
}
