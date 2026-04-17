namespace FitCorePro.Nutrition.Tracking.Domain.Entities
{
    public class AlimentoDietaDia
    {
        protected AlimentoDietaDia() { }
        public AlimentoDietaDia(string id, string nome, string refeicaoDietaDiaId, int quantidadeGramas, double calorias, double carboidratos, double proteinas, double gorduras, double fibras)
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
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public RefeicaoDietaDia RefeicaoDietaDia { get; set; } = default!;
        public string RefeicaoDietaDiaId { get; set; }
        public int QuantidadeGramas { get; set; }
        public double Calorias { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Gorduras { get; set; }
        public double Fibras { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
