namespace FitCorePro.Nutrition.Planning.Application.UseCases.Request
{
    public class PlanoSemanalRequest
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public bool Ativo { get; set; }
        public string UsuarioId { get; set; } = default!;

        public List<PlanoSemanalDiaRequest> PlanoSemanalDias { get; set; } = new();
    }
}
