using FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById
{
    public sealed class GetPlanoSemanalByUsuarioIdHandler
    {
        private readonly IPlanoSemanalRepository _repo;

        public GetPlanoSemanalByUsuarioIdHandler(IPlanoSemanalRepository planoSemanalRepository)
        {
            _repo = planoSemanalRepository;
        }

        public async Task<PlanoSemanalResponse> Handle(GetPlanoSemanalbyUsuarioIdQuery query)
        {
            var plano = await _repo.GetPlanoByUsuarioIdAsync(query.usuarioId);

            if (plano is null) return null;

            return new PlanoSemanalResponse
            {
                Id = plano.Id,
                Nome = plano.Nome,
                Ativo = plano.Ativo,
                IdUsuario = plano.IdUsuario,
                CreatedDate = plano.CreatedDate,
                PlanoSemanalDias = plano.PlanoSemanalDias.Select(d => new PlanoSemanalDiaResponse
                {
                    Id = d.Id,
                    PlanoSemanaId = d.PlanoSemanaId,
                    DiaSemana = d.DiaSemana,
                    CreatedDate = d.CreatedDate,

                    Refeicoes = d.Refeicoes.Select(r => new RefeicaoPlanoSemanalResponse
                    {
                        Id = r.Id,
                       Tipo = r.Tipo,
                       Ordem = r.Ordem,
                       PlanoSemanaDiaId = r.PlanoSemanaDiaId,
                       CreatedDate = r.CreatedDate,

                       AlimentoPlanoSemanais = r.AlimentoPlanoSemanais.Select(a => new AlimentoPlanoSemanalResponse
                       {
                           Id =a.Id,
                           Nome = a.Nome,
                           Gramas = a.Gramas,
                           RefeicaoId = a.RefeicaoId,
                           CreateDate = a.CreatedDate,
                       }).ToList()
                    }).ToList()
                }).ToList()
            };
        }
    }
}
