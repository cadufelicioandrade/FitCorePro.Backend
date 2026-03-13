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


            var banana = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Banana",
                120,
                cafe.Id,
                DateTime.UtcNow);

            var aveia = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Aveia",
                40,
                cafe.Id,
                createdDate: DateTime.UtcNow
            );

            cafe.AdicionarAlimentoPlanoSemanal(banana);
            cafe.AdicionarAlimentoPlanoSemanal(aveia);

            // Almoço
            var almoco = new RefeicaoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                tipo: "Almoco",
                ordem: 2,
                planoSemanalDiaId: segunda.Id,
                createdDate: DateTime.UtcNow
            );

            var arroz = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Arroz Branco",
                gramas: 150,
                almoco.Id,
                createdDate: DateTime.UtcNow
            );

            var frango = new AlimentoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                "Filé de Frango",
                gramas: 200,
                almoco.Id,
                createdDate: DateTime.UtcNow
            );

            almoco.AdicionarAlimentoPlanoSemanal(arroz);
            almoco.AdicionarAlimentoPlanoSemanal(frango);

            // Almoço
            var jantar = new RefeicaoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                tipo: "Jantar",
                ordem: 3,
                planoSemanalDiaId: segunda.Id,
                createdDate: DateTime.UtcNow
            );

            var batataDoce = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Batata Doce",
                gramas: 350,
                jantar.Id,
                createdDate: DateTime.UtcNow
            );

            var carne = new AlimentoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                "Patinho moído",
                gramas: 250,
                jantar.Id,
                createdDate: DateTime.UtcNow
            );

            jantar.AdicionarAlimentoPlanoSemanal(batataDoce);
            jantar.AdicionarAlimentoPlanoSemanal(carne);

            // adiciona refeições ao dia
            segunda.AdicionarRefeicao(cafe);
            segunda.AdicionarRefeicao(almoco);
            segunda.AdicionarRefeicao(jantar);

            // adiciona dia ao plano
            planoSemanal.AdicionarPlanSemanalDia(segunda);

            return planoSemanal;
        }
    }
}
