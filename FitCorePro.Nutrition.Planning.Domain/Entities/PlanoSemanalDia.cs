using System.ComponentModel.DataAnnotations.Schema;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class PlanoSemanalDia
    {
        protected PlanoSemanalDia() { }

        public PlanoSemanalDia(
            string id,
            string planoSemanalId,
            int diaSemana,
            DateTime createdDate)
        {
            Id = id;
            PlanoSemanalId = planoSemanalId;
            DiaSemana = diaSemana;
            CreatedDate = createdDate;
        }

        public string Id { get; set; } = default!;

        public PlanoSemanal PlanoSemanal { get; set; } = default!;
        public string PlanoSemanalId { get; set; } = default!;

        public int DiaSemana { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        private readonly List<RefeicaoPlanoSemanal> _refeicoes = new();
        public IReadOnlyCollection<RefeicaoPlanoSemanal> RefeicoesPlanoSemanal => _refeicoes;

        public void AdicionarRefeicao(RefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            _refeicoes.Add(refeicaoPlanoSemanal);
        }
    }
}
