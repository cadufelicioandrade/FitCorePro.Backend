namespace FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostCriaRefeicao.Request
{
    public class AlimentoPlanoSemanalRequest
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public int Gramas { get; set; }
        public string refeicaoPlanoSemanalId { get; set; } = default!;
    }
}
