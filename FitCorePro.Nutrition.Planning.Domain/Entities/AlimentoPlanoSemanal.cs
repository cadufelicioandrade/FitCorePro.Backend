using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class AlimentoPlanoSemanal
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public DateTime CreatedDate { get; set; }

    }
}
