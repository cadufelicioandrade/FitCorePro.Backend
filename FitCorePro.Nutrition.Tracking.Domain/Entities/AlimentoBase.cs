namespace FitCorePro.Nutrition.Tracking.Domain.Entities
{
    public class AlimentoBase
    {
        public AlimentoBase(string id, string nome, int gramas, double calorias, double carboidratos, double proteinas, double gorduras, double fibras)
        {
            Id = id;
            Nome = nome;
            Gramas = gramas;
            Calorias = calorias;
            Carboidratos = carboidratos;
            Proteinas = proteinas;
            Gorduras = gorduras;
            Fibras = fibras;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public int Gramas { get; set; }
        public double Calorias { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Gorduras { get; set; }
        public double Fibras { get; set; }
    }
}
