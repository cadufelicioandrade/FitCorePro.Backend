using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class PlanoSemanalDia
    {
        public string Id { get; set; } = default;
        public string PlanoSemanalId { get; set; } = default;
        public int DiaSemana { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<RefeicaoPlanoSemanal> Refeicoes { get; set; } = new();
    }
}
