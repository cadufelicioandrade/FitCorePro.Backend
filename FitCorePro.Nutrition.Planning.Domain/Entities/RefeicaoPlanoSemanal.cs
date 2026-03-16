namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class RefeicaoPlanoSemanal
    {
        public string Id { get; private set; } = default!;
        public string Tipo { get; private set; } = default!;
        public int Ordem { get; private set; }
        public string PlanoSemanalDiaId { get; private set; } = default!;
        public DateTime CreatedDate { get; private set; }

        private readonly List<AlimentoPlanoSemanal> _alimentosPlanoSemanais = new();
        public IReadOnlyCollection<AlimentoPlanoSemanal> AlimentosPlanoSemanais => _alimentosPlanoSemanais;

        protected RefeicaoPlanoSemanal() { }

        public RefeicaoPlanoSemanal(
            string id,
            string tipo,
            int ordem,
            string planoSemanalDiaId,
            DateTime createdDate)
        {
            Id = id;
            Tipo = tipo;
            Ordem = ordem;
            PlanoSemanalDiaId = planoSemanalDiaId;
            CreatedDate = createdDate;
        }

        public void AdicionarAlimentoPlanoSemanal(AlimentoPlanoSemanal alimento)
        {
            _alimentosPlanoSemanais.Add(alimento);
        }
    }
}
