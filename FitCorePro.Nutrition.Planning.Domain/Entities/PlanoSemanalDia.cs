using System.ComponentModel.DataAnnotations.Schema;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class PlanoSemanalDia
    {
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

        public string Id { get; set; } = default;
        
        public PlanoSemanal PlanoSemanal { get; set; }
        public string PlanoSemanalId { get; set; } = default;

        public int DiaSemana { get; set; }
        public DateTime CreatedDate { get; set; }

        private List<RefeicaoPlanoSemanal> _refeicoes { get; set; } = new();

        public IReadOnlyCollection<RefeicaoPlanoSemanal> RefeicoesPlanoSemanal => _refeicoes;

        public void AdicionarRefeicao(RefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            _refeicoes.Add(refeicaoPlanoSemanal);
        }
    }
}
