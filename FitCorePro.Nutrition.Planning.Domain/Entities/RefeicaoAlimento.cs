using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class RefeicaoAlimento
    {
        public string Id { get; private set; } = default!;
        public string RefeicaoId { get; private set; } = default!;
        public string AlimentoId { get; private set; } = default!;
        public long Gramas { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public RefeicaoPlanoSemanal Refeicao { get; private set; } = default!;
        public AlimentoPlanoSemanal Alimento { get; private set; } = default!;

        protected RefeicaoAlimento() { }

        public RefeicaoAlimento(
            string id,
            string refeicaoId,
            string alimentoId,
            long gramas,
            DateTime createdDate)
        {
            Id = id;
            RefeicaoId = refeicaoId;
            AlimentoId = alimentoId;
            Gramas = gramas;
            CreatedDate = createdDate;
        }

    }
}
