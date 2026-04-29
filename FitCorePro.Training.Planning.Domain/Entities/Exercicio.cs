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

        public string Id { get; private set; }
        public string TipoExercicio { get; private set; }
        public string Serie { get; private set; }
        public string Carga { get; private set; }
        public string TreinoDiaId { get; private set; }
        public TreinoDia TreinoDia { get; set; }

    }
}
