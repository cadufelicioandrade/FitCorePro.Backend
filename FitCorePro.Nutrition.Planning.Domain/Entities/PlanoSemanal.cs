using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Domain.Entities
{
    public class PlanoSemanal
    {
        protected PlanoSemanal() { }

        public PlanoSemanal(
            string id,
            string nome,
            bool ativo,
            string usuarioId,
            DateTime createdDate)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
            UsuarioId = usuarioId;
            CreatedDate = createdDate;
        }

        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public bool Ativo { get; set; }
        public string UsuarioId { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        private List<PlanoSemanalDia> _planoSemanalDias { get; set; } = new();
        public IReadOnlyCollection<PlanoSemanalDia> PlanoSemanalDias => _planoSemanalDias;

        public void AdicionarPlanSemanalDia(PlanoSemanalDia planoSemanalDia)
        {
            _planoSemanalDias.Add(planoSemanalDia);
        }
    }
}
