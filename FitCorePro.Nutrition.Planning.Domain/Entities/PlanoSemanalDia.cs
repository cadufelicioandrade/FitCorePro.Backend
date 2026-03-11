namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class PlanoSemanalDia
    {
        public PlanoSemanalDia(
            string id,
            string planoSemanalId,
            int diaSemana,
            DateTime createdDate,
            List<RefeicaoPlanoSemanal> refeicoes)
        {
            Id = id;
            PlanoSemanalId = planoSemanalId;
            DiaSemana = diaSemana;
            CreatedDate = createdDate;
        }

        public string Id { get; set; } = default;
        public string PlanoSemanalId { get; set; } = default;
        public int DiaSemana { get; set; }
        public DateTime CreatedDate { get; set; }

        private List<RefeicaoPlanoSemanal> _refeicoes { get; set; } = new();

        public IReadOnlyCollection<RefeicaoPlanoSemanal> Refeicoes => _refeicoes;

        public void AdicionarRefeicao(RefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            _refeicoes.Add(refeicaoPlanoSemanal);
        }
    }
}
