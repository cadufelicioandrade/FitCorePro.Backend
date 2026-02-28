using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response
{
    public sealed class PlanoSemanalDiaResponse
    {
        public string Id { get; set; } = default;
        public string PlanoSemanaId { get; set; } = default;
        public int DiaSemana { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<RefeicaoPlanoSemanalResponse> Refeicoes { get; set; } = new();
    }
}
