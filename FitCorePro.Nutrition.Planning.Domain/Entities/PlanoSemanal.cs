using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class PlanoSemanal
    {
        public string Id { get; set; } = default;
        public string Nome { get; set; } = default;
        public bool Ativo { get; set; }
        public string UsuarioId { get; set; } = default;
        public DateTime CreatedDate { get; set; }
        public List<PlanoSemanalDia> PlanoSemanalDias { get; set; } = new();
    }
}
