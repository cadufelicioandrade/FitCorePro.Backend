namespace FitCorePro.Nutrition.Tracking.Domain.Entities
{
    public class DietaDia
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public DateTime DataDieta { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        private List<RefeicaoDietaDia> _refeicoesDietaDia = new();

        public DietaDia(string id, string usuarioId, DateTime dataDieta)
        {
            Id = id;
            UsuarioId = usuarioId;
            DataDieta = dataDieta;
        }

        public List<RefeicaoDietaDia> RefeicoesDietaDia => _refeicoesDietaDia;

        public void AdicionarRefeicaoDietaDia(RefeicaoDietaDia refeicaoDietaDia)
        {
            _refeicoesDietaDia.Add(refeicaoDietaDia);
        }

    }
}
