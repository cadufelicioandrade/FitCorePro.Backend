namespace FitCorePro.Nutrition.Tracking.Domain.Entities
{
    public class DietaDia
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public DateTime DataDieta { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        private readonly List<RefeicaoDietaDia> _refeicoesDietaDia = new();
        public IReadOnlyCollection<RefeicaoDietaDia> RefeicoesDietaDia => _refeicoesDietaDia;

        protected DietaDia() { }
        public DietaDia(string id, string usuarioId, DateTime dataDieta)
        {
            Id = id;
            UsuarioId = usuarioId;
            DataDieta = dataDieta;
        }

        public void AdicionarRefeicaoDietaDia(RefeicaoDietaDia refeicaoDietaDia)
        {
            _refeicoesDietaDia.Add(refeicaoDietaDia);
        }

    }
}
