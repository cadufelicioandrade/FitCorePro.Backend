namespace FitCorePro.Training.Planning.Domain.Entities
{
    public class Exercicio
    {
        public Exercicio(string id, string tipoExercicio, string serie, string carga, string treinoDiaId)
        {
            Id = id;
            TipoExercicio = tipoExercicio;
            Serie = serie;
            Carga = carga;
            TreinoDiaId = treinoDiaId;
        }

        public string Id { get; set; }
        public string TipoExercicio { get; set; }
        public string Serie { get; set; }
        public string Carga { get; set; }
        public string TreinoDiaId { get; set; }
        public TreinoDia TreinoDia { get; set; }

    }
}
