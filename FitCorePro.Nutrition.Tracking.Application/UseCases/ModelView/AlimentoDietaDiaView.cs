namespace FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView
{
    public class AlimentoDietaDiaView
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string RefeicaoDietaDiaId { get; set; }
        public int QuantidadeGramas { get; set; }
        public double Calorias { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Gorduras { get; set; }
        public double Fibras { get; set; }
        public string CreatedDate { get; set; }

    }
}
