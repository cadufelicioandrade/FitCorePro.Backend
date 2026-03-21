namespace FitCorePro.Nutrition.Planning.Application.UseCases.Request
{
    public class RefeicaoPlanoSemanalRequest
    {
        public string Id { get; set; }
        public string tipo { get; set; }
        public int Ordem { get; set; }
        public string PlanoSemanalDiaId { get; set; }
        public List<AlimentoPlanoSemanalRequest> AlimentoPlanoSemanais { get; set; }
    }
}
