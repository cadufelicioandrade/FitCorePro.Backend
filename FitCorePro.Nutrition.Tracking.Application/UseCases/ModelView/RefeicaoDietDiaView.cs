namespace FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView
{
    public class RefeicaoDietDiaView
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ordem { get; set; }
        public string DietaDiaId { get; set; }
        public List<AlimentoDietaDiaView> AlimentoDietaDiaViews { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
