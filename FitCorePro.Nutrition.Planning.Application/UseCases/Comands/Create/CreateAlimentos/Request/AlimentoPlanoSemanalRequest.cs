namespace FitCorePro.Nutrition.Planning.Application.UseCases.Comands.Create.PostAlimentos.Request
{
    public class AlimentoPlanoSemanalRequest
    {
        public AlimentoPlanoSemanalRequest(
            string id,
            string nome,
            int gramas,
            string refeicaoPlanoSemanalId)
        {
            Id = id;
            Nome = nome;
            Gramas = gramas;
            RefeicaoPlanoSemanalId = refeicaoPlanoSemanalId;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public int Gramas { get; set; }
        public string RefeicaoPlanoSemanalId { get; set; }

    }
}
