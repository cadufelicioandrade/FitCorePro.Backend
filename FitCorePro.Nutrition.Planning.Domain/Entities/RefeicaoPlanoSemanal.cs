using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class RefeicaoPlanoSemanal
    {
        public string Id { get; private set; } = default!;
        public string Tipo { get; private set; } = default!;
        public int Ordem { get; private set; }
        public string PlanoSemanalDiaId { get; private set; } = default!;
        public DateTime CreatedDate { get; private set; }

        private readonly List<RefeicaoAlimento> _refeicaoAlimentos = new();
        public IReadOnlyCollection<RefeicaoAlimento> RefeicaoAlimentos => _refeicaoAlimentos;

        protected RefeicaoPlanoSemanal() { }

        public RefeicaoPlanoSemanal(
            string id,
            string tipo,
            int ordem,
            string planoSemanalDiaId,
            DateTime createdDate)
        {
            Id = id;
            Tipo = tipo;
            Ordem = ordem;
            PlanoSemanalDiaId = planoSemanalDiaId;
            CreatedDate = createdDate;
        }

        public void AdicionarRefeicaoAlimento(RefeicaoAlimento refeicaoAlimento)
        {
            _refeicaoAlimentos.Add(refeicaoAlimento);
        }
    }
}
