using FitCorePro.Training.Planning.Domain.Entities;

namespace FitCorePro.Training.Planning.Application.UseCases.ModelView
{
    public class TreinoDiaView
    {
        public string Id { get; set; }
        public int DiaSemana { get; set; }

        public List<ExercicioView> Exercicios { get; set; } = new();
    }
}
