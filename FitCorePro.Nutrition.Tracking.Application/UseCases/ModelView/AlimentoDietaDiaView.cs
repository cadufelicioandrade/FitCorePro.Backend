namespace FitCorePro.Nutrition.Tracking.Application.UseCases.ModelView
{
    public class AlimentoDietaDiaView
    {
        public AlimentoDietaDiaView(string id, string nome, string refeicaoDietaDiaId, int quantidadeGramas, double calorias, double carboidratos, double proteinas, double gorduras, double fibras, string createdDate)
        {
            Id = id;
            Nome = nome;
            RefeicaoDietaDiaId = refeicaoDietaDiaId;
            QuantidadeGramas = quantidadeGramas;
            Calorias = calorias;
            Carboidratos = carboidratos;
            Proteinas = proteinas;
            Gorduras = gorduras;
            Fibras = fibras;
            CreatedDate = createdDate;
        }

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
