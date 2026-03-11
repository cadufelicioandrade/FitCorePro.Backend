using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Nutrition.Planning.Infrastructure.Repositories
{
    public class PlanoSemanalRepository : IPlanoSemanalRepository
    {
        private readonly PlanningDbContext _context;

        public PlanoSemanalRepository(PlanningDbContext context)
        {
            _context = context;
        }

        public async Task<PlanoSemanal?> GetPlanoByUsuarioIdAsync(string usuarioId)
        {
            var plano = GetMock(usuarioId);
            return await Task.FromResult<PlanoSemanal?>(plano);

            //return await _context.PlanosSemanais
            //    .AsNoTracking()
            //    .Include(p => p.PlanoSemanalDias)
            //        .ThenInclude(d => d.Refeicoes)
            //            .ThenInclude(r => r.RefeicaoAlimentos)
            //                .ThenInclude(ra => ra.Alimento)
            //    .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);
        }

        private PlanoSemanal GetMock(string usuarioId)
        {
            var planoSemanal = new PlanoSemanal(
                id: Guid.NewGuid().ToString(),
                nome: "Plano Hipertrofia",
                ativo: true,
                usuarioId: usuarioId,
                createdDate: DateTime.Now
);

            // =====================
            // SEGUNDA FEIRA
            // =====================
            var segunda = new PlanoSemanalDia(
                id: Guid.NewGuid().ToString(),
                planoSemanalId: planoSemanal.Id,
                diaSemana: 1,
                createdDate: DateTime.UtcNow,
                refeicoes: new List<RefeicaoPlanoSemanal>()
            );

            // Café da manhã
            var cafe = new RefeicaoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                tipo: "CafeDaManha",
                ordem: 1,
                planoSemanalDiaId: segunda.Id,
                createdDate: DateTime.UtcNow
            );

            var banana = new RefeicaoAlimento(
                id: Guid.NewGuid().ToString(),
                refeicaoId: cafe.Id,
                alimentoId: "banana-id",
                gramas: 120,
                createdDate: DateTime.UtcNow
            );

            var aveia = new RefeicaoAlimento(
                id: Guid.NewGuid().ToString(),
                refeicaoId: cafe.Id,
                alimentoId: "aveia-id",
                gramas: 40,
                createdDate: DateTime.UtcNow
            );

            cafe.AdicionarRefeicaoAlimento(banana);
            cafe.AdicionarRefeicaoAlimento(aveia);

            // Almoço
            var almoco = new RefeicaoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                tipo: "Almoco",
                ordem: 2,
                planoSemanalDiaId: segunda.Id,
                createdDate: DateTime.UtcNow
            );

            var arroz = new RefeicaoAlimento(
                id: Guid.NewGuid().ToString(),
                refeicaoId: almoco.Id,
                alimentoId: "arroz-id",
                gramas: 150,
                createdDate: DateTime.UtcNow
            );

            var frango = new RefeicaoAlimento(
                id: Guid.NewGuid().ToString(),
                refeicaoId: almoco.Id,
                alimentoId: "frango-id",
                gramas: 200,
                createdDate: DateTime.UtcNow
            );

            almoco.AdicionarRefeicaoAlimento(arroz);
            almoco.AdicionarRefeicaoAlimento(frango);

            // adiciona refeições ao dia
            segunda.AdicionarRefeicao(cafe);
            segunda.AdicionarRefeicao(almoco);

            // adiciona dia ao plano
            planoSemanal.AdicionarPlanSemanalDia(segunda);

            return planoSemanal;
        }
    }
}
