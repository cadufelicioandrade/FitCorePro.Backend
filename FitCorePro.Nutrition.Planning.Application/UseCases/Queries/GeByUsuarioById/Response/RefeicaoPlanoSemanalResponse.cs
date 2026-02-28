using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response
{
    public sealed class RefeicaoPlanoSemanalResponse
    {
        public string Id { get; set; } = default;
        public string Tipo { get; set; } = default;
        public int Ordem { get; set; }
        public string PlanoSemanaDiaId { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<AlimentoPlanoSemanalResponse> AlimentoPlanoSemanais { get; set; } = new();

    }
}
