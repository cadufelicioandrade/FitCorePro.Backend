namespace FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView
{
    public class DietaDiaView
    {
        public DietaDiaView(string id, string usuarioId, DateTime dataDieta, DateTime createdDate)
        {
            Id = id;
            UsuarioId = usuarioId;
            DataDieta = dataDieta;
            CreatedDate = createdDate;
        }

        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public DateTime DataDieta { get; set; }
        public List<RefeicaoDietDiaView> RefeicaoDietDiaViews { get; set; } = new();
        public DateTime CreatedDate { get; set; }

    }
}
