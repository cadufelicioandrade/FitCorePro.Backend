using FitCorePro.Nutrition.Planning.Application.UseCases.Response;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Request
{
    public class PlanoSemanalDiaRequest
    {
        public string Id { get; set; } = default!;
        public string PlanoSemanalId { get; set; } = default!;
        public int DiaSemana { get; set; }

        public List<RefeicaoPlanoSemanalRequest> RefeicoesPlanoSemanal { get; set; } = new();
    }
}
