namespace FitCorePro.Training.Planning.Domain.Entities
{
    public class PlanoTreinoSemanal
    {
        public PlanoTreinoSemanal(string id, bool ativo, string titulo, string usuarioId)
        {
            Id = id;
            Ativo = ativo;
            Titulo = titulo;
            UsuarioId = usuarioId;
        }

        public string Id { get; set; }
        public string Titulo { get; set; }
        public bool Ativo { get; set; }
        public string UsuarioId { get; set; }

        private List<TreinoDia> _treinosDia { get; set; } = new();
        public IReadOnlyCollection<TreinoDia> TreinosDia => _treinosDia;

        public void AdicionarTreinoDia(TreinoDia treioDia)
        {
            _treinosDia.Add(treioDia);
        }

    }
}
