namespace FitCorePro.Nutrition.Planning.Application.UseCases.Response
{
    public sealed class AlimentoPlanoSemanalResponse
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public int Gramas { get; set; }
        public string RefeicaoPlanoSemanalId { get; set; } = default!;

    }
}
