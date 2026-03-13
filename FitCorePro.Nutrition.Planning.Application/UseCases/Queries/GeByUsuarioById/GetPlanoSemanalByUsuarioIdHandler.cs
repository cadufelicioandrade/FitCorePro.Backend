using FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById.Response;
using FitCorePro.Nutrition.Planning.Domain.Repositories;

namespace FitCorePro.Nutrition.Planning.Application.UseCases.Queries.GeByUsuarioById
{
    public sealed class GetPlanoSemanalByUsuarioIdHandler
    {
        private readonly IPlanoSemanalRepository _repo;

        public GetPlanoSemanalByUsuarioIdHandler(IPlanoSemanalRepository planoSemanalRepository)
        {
            _repo = planoSemanalRepository;
        }

        public async Task<PlanoSemanalResponse?> Handle(GetPlanoSemanalByUsuarioIdQuery query)
        {
            var plano = await _repo.GetPlanoByUsuarioIdAsync(query.UsuarioId);

            if (plano is null)
                return null;

            return new PlanoSemanalResponse
            {
                Id = plano.Id,
                Nome = plano.Nome,
                Ativo = plano.Ativo,
                UsuarioId = plano.UsuarioId,
                CreatedDate = plano.CreatedDate,
                PlanoSemanalDias = plano.PlanoSemanalDias
                    .OrderBy(d => d.DiaSemana)
                    .Select(d => new PlanoSemanalDiaResponse
                    {
                        Id = d.Id,
                        PlanoSemanalId = d.PlanoSemanalId,
                        DiaSemana = d.DiaSemana,
                        CreatedDate = d.CreatedDate,
                        Refeicoes = d.Refeicoes
                            .OrderBy(r => r.Ordem)
                            .Select(r => new RefeicaoPlanoSemanalResponse
                            {
                                Id = r.Id,
                                Tipo = r.Tipo,
                                Ordem = r.Ordem,
                                PlanoSemanalDiaId = r.PlanoSemanalDiaId,
                                CreatedDate = r.CreatedDate,
                                AlimentoPlanoSemanais = r.AlimentosPlanoSemanais
                                    .Select(ra => new AlimentoPlanoSemanalResponse
                                    {
                                        Id = ra.Id,
                                        Nome = ra.Nome,
                                        Gramas = (int)ra.Gramas,
                                        RefeicaoId = ra.RefeicaoPlanoSemanalId,
                                        CreatedDate = ra.CreatedDate
                                    })
                                    .ToList()
                            })
                            .ToList()
                    })
                    .ToList()
            };
        }
    }
}
