namespace FitCorePro.Nutrition.Planning.Application.UseCases.Response
{
    public sealed class PlanoSemanalDiaResponse
    {
        public string Id { get; set; } = default!;
        public string PlanoSemanalId { get; set; } = default!;
        public int DiaSemana { get; set; }

        public List<RefeicaoPlanoSemanalResponse> RefeicoesPlanoSemanal { get; set; } = new();
    }
}
