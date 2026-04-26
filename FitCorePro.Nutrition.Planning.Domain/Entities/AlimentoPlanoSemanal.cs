using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class AlimentoPlanoSemanal
    {
        protected AlimentoPlanoSemanal()
        {
            
        }

        public AlimentoPlanoSemanal(string id, string nome, int gramas, string refeicaoPlanoSemanalId)
        {
            Id = id;
            Nome = nome;
            Gramas = gramas;
            RefeicaoPlanoSemanalId = refeicaoPlanoSemanalId;
        }

        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public int Gramas { get; set; }
        public RefeicaoPlanoSemanal RefeicaoPlanoSemanal { get; set; } = default!;
        public string RefeicaoPlanoSemanalId { get; set; }
        public DateOnly CreatedDate { get; set; } 

    }
}
