namespace FitCorePro.Nutrition.Tracking.Domain.Entities
{
    public class RefeicaoDietaDia
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ordem { get; set; }
        public string DietaDiaId { get; set; }

        public DateTime CreatedDate { get; set; }

        private List<AlimentoDietaDia> _alimentosDietaDia = new();

        public RefeicaoDietaDia(string id, string titulo, int ordem, string dietaDiaId)
        {
            Id = id;
            Titulo = titulo;
            Ordem = ordem;
            DietaDiaId = dietaDiaId;
        }

        public List<AlimentoDietaDia> AlimentosDietaDia => _alimentosDietaDia;


        public void AdicionarAlimentoDietaDia(AlimentoDietaDia alimentoDietaDia)
        {
            _alimentosDietaDia.Add(alimentoDietaDia);
        }
    }
}
