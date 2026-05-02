namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class RefeicaoPlanoSemanal
    {
        public string Id { get; set; } = default!;
        public string Tipo { get; set; } = default!;
        public int Ordem { get; set; }
        public string PlanoSemanalDiaId { get; set; } = default!;
        public PlanoSemanalDia PlanoSemanalDia { get; set; }

        public DateTime CreatedDate { get; set; } 

        private readonly List<AlimentoPlanoSemanal> _alimentosPlanoSemanais = new();
        public IReadOnlyCollection<AlimentoPlanoSemanal> AlimentosPlanoSemanais => _alimentosPlanoSemanais;

        protected RefeicaoPlanoSemanal() { }

        public RefeicaoPlanoSemanal(
            string id,
            string tipo,
            int ordem,
            string planoSemanalDiaId)
        {
            Id = id;
            Tipo = tipo;
            Ordem = ordem;
            PlanoSemanalDiaId = planoSemanalDiaId;
        }

        public void AdicionarAlimentoPlanoSemanal(AlimentoPlanoSemanal alimento)
        {
            _alimentosPlanoSemanais.Add(alimento);
        }
    }
}
