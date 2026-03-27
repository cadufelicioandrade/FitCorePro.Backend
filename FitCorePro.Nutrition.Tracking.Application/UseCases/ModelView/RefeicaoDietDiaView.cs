namespace FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView
{
    public class RefeicaoDietDiaView
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ordem { get; set; }
        public string DietaDiaId { get; set; }
        public List<AlimentoDietaDiaView> AlimentosDietaDia { get; set; }
        public string CreatedDate { get; set; }

    }
}
