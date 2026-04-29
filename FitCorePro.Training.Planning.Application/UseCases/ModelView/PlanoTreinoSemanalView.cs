namespace FitCorePro.Training.Planning.Application.UseCases.ModelView
{
    public class PlanoTreinoSemanalView
    {
        public string Id { get; set; }
        public bool Ativo { get; set; }
        public List<TreinoDiaView> TreinosDia { get; set; } = new();
    }
}
