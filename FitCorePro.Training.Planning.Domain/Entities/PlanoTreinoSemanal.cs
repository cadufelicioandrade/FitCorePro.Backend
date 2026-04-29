namespace FitCorePro.Training.Planning.Domain.Entities
{
    public class PlanoTreinoSemanal
    {
        public PlanoTreinoSemanal(string id, bool ativo)
        {
            Id = id;
            Ativo = ativo;
        }

        public string Id { get; private set; }
        public bool Ativo { get; private set; }

        private List<TreinoDia> _treinosDia { get; set; } = new();
        public IReadOnlyCollection<TreinoDia> TreinosDia => _treinosDia;

        public void AdicionarTreinoDia(TreinoDia treioDia)
        {
            _treinosDia.Add(treioDia);
        }

    }
}
