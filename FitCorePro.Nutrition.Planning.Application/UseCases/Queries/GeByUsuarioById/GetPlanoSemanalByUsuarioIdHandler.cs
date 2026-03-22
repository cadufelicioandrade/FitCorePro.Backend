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

        public async Task<PlanoSemanalResponse?> HandleAsync(GetPlanoSemanalByUsuarioIdQuery query)
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
                PlanoSemanalDias = plano.PlanoSemanalDias
                    .OrderBy(d => d.DiaSemana)
                    .Select(d => new PlanoSemanalDiaResponse
                    {
                        Id = d.Id,
                        PlanoSemanalId = d.PlanoSemanalId,
                        DiaSemana = d.DiaSemana,
                        Refeicoes = d.Refeicoes
                            .OrderBy(r => r.Ordem)
                            .Select(r => new RefeicaoPlanoSemanalResponse
                            {
                                Id = r.Id,
                                Tipo = r.Tipo,
                                Ordem = r.Ordem,
                                PlanoSemanalDiaId = r.PlanoSemanalDiaId,
                                AlimentoPlanoSemanais = r.AlimentosPlanoSemanais
                                    .Select(ra => new AlimentoPlanoSemanalResponse
                                    {
                                        Id = ra.Id,
                                        Nome = ra.Nome,
                                        Gramas = (int)ra.Gramas,
                                        RefeicaoPlanoSemanalId = ra.RefeicaoPlanoSemanalId,
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
