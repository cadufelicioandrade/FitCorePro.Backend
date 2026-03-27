namespace FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView
{
    public class DietaDiaView
    {
        public DietaDiaView(string id, string usuarioId, string dataDieta, string createdDate)
        {
            Id = id;
            UsuarioId = usuarioId;
            DataDieta = dataDieta;
            CreatedDate = createdDate;
        }

        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string DataDieta { get; set; }
        public List<RefeicaoDietDiaView> RefeicoesDietaDia { get; set; } = new();
        public string CreatedDate { get; set; }

    }
}
