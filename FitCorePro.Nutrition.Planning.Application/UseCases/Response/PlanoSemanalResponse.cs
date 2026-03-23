namespace FitCorePro.Nutrition.Planning.Application.UseCases.Response
{
    public sealed class PlanoSemanalResponse
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public bool Ativo { get; set; }
        public string UsuarioId { get; set; } = default!;

        public List<PlanoSemanalDiaResponse> PlanoSemanalDias { get; set; } = new();

    }
}
