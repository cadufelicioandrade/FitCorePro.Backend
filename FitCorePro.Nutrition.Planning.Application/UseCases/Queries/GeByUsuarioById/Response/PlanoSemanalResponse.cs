using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response
{
    public sealed class PlanoSemanalResponse
    {
        public string Id { get; set; } = default;
        public string Nome { get; set; } = default;
        public bool Ativo { get; set; }

        public string IdUsuario { get; set; } = default;
        public DateTime CreatedDate { get; set; }

        public List<PlanoSemanalDiaResponse> PlanoSemanalDias { get; set; } = new();

    }
}
