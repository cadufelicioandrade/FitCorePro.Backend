namespace FitCorePro.Training.Planning.Domain.Entities
{
    public class TreinoDia
    {
        public TreinoDia(string id, int diaSemana, string planoTreinoSemanalId)
        {
            Id = id;
            DiaSemana = diaSemana;
            PlanoTreinoSemanalId = planoTreinoSemanalId;
        }

        public string Id { get; private set; }
        public int DiaSemana { get; private set; }
        public string PlanoTreinoSemanalId { get; private set; }
        public PlanoTreinoSemanal PlanoTreinoSemanal { get; set; }

        private readonly List<Exercicio> _exercicios = new();

        public IReadOnlyCollection<Exercicio> Exercicios => _exercicios;

        public void AdicionarExercicio(Exercicio exercicio)
        {
            _exercicios.Add(exercicio);
        }

    }
}
