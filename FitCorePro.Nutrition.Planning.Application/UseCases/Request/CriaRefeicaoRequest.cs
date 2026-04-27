namespace FitCorePro.Nutrition.Planning.Application.UseCases.Request
{
    public class CriaRefeicaoRequest
    {
        public string planoSemanalId { get; set; }
        public string PlanoSemanalDiaId { get; set; }
        public int DiaSemana { get; set; }
        public string TipoRefeicao { get; set; }
        public List<AlimentoPlanoSemanalRequest> AlimentoPlanoSemanais { get; set; }
    }
}
