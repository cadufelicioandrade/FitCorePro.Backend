using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response
{
    public sealed class AlimentoPlanoSemanalResponse
    {
        public string Id { get; set; } = default;
        public string Nome { get; set; } = default;
        public int Gramas { get; set; }
        public string RefeicaoId { get; set; } = default;
        public DateTime CreateDate { get; set; }

    }
}
