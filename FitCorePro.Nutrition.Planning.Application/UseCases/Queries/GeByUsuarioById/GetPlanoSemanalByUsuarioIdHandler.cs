using FitCorePro.Nutrition.Planning.Application.UseCases.Request;
using FitCorePro.Nutrition.Planning.Application.UseCases.Response;
using FitCorePro.Nutrition.Planning.Domain.Entities;
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

        public async Task<PlanoSemanalResponse?> GetHandleAsync(GetPlanoSemanalByUsuarioIdQuery query)
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
                        RefeicoesPlanoSemanal = d.RefeicoesPlanoSemanal
                            .OrderBy(r => r.Ordem)
                            .Select(r => new RefeicaoPlanoSemanalResponse
                            {
                                Id = r.Id,
                                Tipo = r.Tipo,
                                Ordem = r.Ordem,
                                PlanoSemanalDiaId = r.PlanoSemanalDiaId,
                                AlimentosPlanoSemanal = r.AlimentosPlanoSemanais
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

        public async Task<string> AddHandleAsync(string usuarioId, PlanoSemanalRequest request)
        {
            var planoSemanalId = Guid.NewGuid().ToString();
            

            var planoSemanal = new PlanoSemanal(planoSemanalId, request.Nome, true, request.UsuarioId, DateOnly.FromDateTime(DateTime.Now));

            request.PlanoSemanalDias.ForEach(diaRequest => {
                var planoSemanalDiaId = Guid.NewGuid().ToString();

                var planoSemanalDia = new PlanoSemanalDia(
                    planoSemanalDiaId,
                    planoSemanalId,
                    diaRequest.DiaSemana,
                    DateOnly.FromDateTime(DateTime.Now));

                planoSemanal.AdicionarPlanSemanalDia(planoSemanalDia);

                diaRequest.RefeicoesPlanoSemanal.ForEach(refeicaoRequest =>
                {
                    var refeicaoId = Guid.NewGuid().ToString();
                    var refeicaoPlanoSemanal = new RefeicaoPlanoSemanal(
                        refeicaoId,
                        refeicaoRequest.tipo,
                        refeicaoRequest.Ordem, planoSemanalDiaId);

                    planoSemanalDia.AdicionarRefeicao(refeicaoPlanoSemanal);

                    refeicaoRequest.AlimentosPlanoSemanal.ForEach(alimentoRequest =>
                    {
                        var alimentoId = Guid.NewGuid().ToString();
                        var alimentoPlanoSemanal = new AlimentoPlanoSemanal(
                            alimentoId,
                            alimentoRequest.Nome,
                            alimentoRequest.Gramas,
                            refeicaoId);

                        refeicaoPlanoSemanal.AdicionarAlimentoPlanoSemanal(alimentoPlanoSemanal);
                    });
                });

            });

            return await _repo.AdicionarPlanoSemanalAsync(planoSemanal);
        }
    }
}
