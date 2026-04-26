namespace FitCorePro.Nutrition.Tracking.Domain.Entities
{
    public class DietaDia
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public DateOnly DataDieta { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        private readonly List<RefeicaoDietaDia> _refeicoesDietaDia = new();
        public IReadOnlyCollection<RefeicaoDietaDia> RefeicoesDietaDia => _refeicoesDietaDia;

        protected DietaDia() { }

        public DietaDia(string id, string usuarioId, DateOnly dataDieta)
        {
            Id = id;
            UsuarioId = usuarioId;
            DataDieta = dataDieta;
            CreatedDate = DateTime.UtcNow;
        }

        public void AdicionarRefeicaoDietaDia(RefeicaoDietaDia refeicaoDietaDia)
        {
            _refeicoesDietaDia.Add(refeicaoDietaDia);
        }
    }
}