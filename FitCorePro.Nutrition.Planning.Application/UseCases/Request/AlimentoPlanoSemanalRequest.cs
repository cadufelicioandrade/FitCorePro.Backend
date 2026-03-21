namespace FitCorePro.Nutrition.Planning.Application.UseCases.Request
{
    public class AlimentoPlanoSemanalRequest
    {
        public AlimentoPlanoSemanalRequest(string id, string nome, int gramas, string refeicaoPlanoSemanalId)
        {
            Id = id;
            Nome = nome;
            Gramas = gramas;
            this.RefeicaoPlanoSemanalId = refeicaoPlanoSemanalId;
        }

        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public int Gramas { get; set; }
        public string RefeicaoPlanoSemanalId { get; set; } = default!;
    }
}
