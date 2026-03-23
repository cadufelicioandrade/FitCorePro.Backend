namespace FitCorePro.Nutrition.Planning.Application.UseCases.Response
{
    public sealed class RefeicaoPlanoSemanalResponse
    {
        public string Id { get; set; } = default!;
        public string Tipo { get; set; } = default!;
        public int Ordem { get; set; }
        public string PlanoSemanalDiaId { get; set; } = default!;

        public List<AlimentoPlanoSemanalResponse> AlimentosPlanoSemanal { get; set; } = new();

    }
}
