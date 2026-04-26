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

        public async Task<string> AdicionarPlanoSemanalAsync(PlanoSemanal planoSemanal)
        {
            _context.PlanosSemanal.Add(planoSemanal);
            var result = await _context.SaveChangesAsync();

            if (result > 0) return "Plano semanal incluído com sucesso!";
            return "Falha ao incluir plano semana.";
        }

        public async Task<PlanoSemanal?> GetPlanoByUsuarioIdAsync(string usuarioId)
        {
            return await _context.PlanosSemanal.AsNoTracking()
                .Include(p => p.PlanoSemanalDias)
                    .ThenInclude(d => d.RefeicoesPlanoSemanal)
                        .ThenInclude(r => r.AlimentosPlanoSemanais)
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);

            //var plano = GetMock(usuarioId);
            //return await Task.FromResult<PlanoSemanal?>(plano);
        }

        private PlanoSemanal GetMock(string usuarioId)
        {
            var planoSemanal = new PlanoSemanal(
                id: Guid.NewGuid().ToString(),
                nome: "Plano Hipertrofia",
                ativo: true,
                usuarioId: usuarioId,
                createdDate: DateOnly.FromDateTime(DateTime.Now)
            );

            // =====================
            // SEGUNDA FEIRA
            // =====================
            var segunda = new PlanoSemanalDia(
                id: Guid.NewGuid().ToString(),
                planoSemanalId: planoSemanal.Id,
                diaSemana: 1,
                createdDate: DateOnly.FromDateTime(DateTime.Now)
            );

            // Café da manhã
            var cafe = new RefeicaoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                tipo: "CafeDaManha",
                ordem: 1,
                planoSemanalDiaId: segunda.Id
            );


            var banana = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Banana",
                120,
                cafe.Id);

            var aveia = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Aveia",
                40,
                cafe.Id
            );

            cafe.AdicionarAlimentoPlanoSemanal(banana);
            cafe.AdicionarAlimentoPlanoSemanal(aveia);

            // Almoço
            var almoco = new RefeicaoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                tipo: "Almoco",
                ordem: 2,
                planoSemanalDiaId: segunda.Id
            );

            var arroz = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Arroz Branco",
                gramas: 150,
                almoco.Id
            );

            var frango = new AlimentoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                "Filé de Frango",
                gramas: 200,
                almoco.Id
            );

            almoco.AdicionarAlimentoPlanoSemanal(arroz);
            almoco.AdicionarAlimentoPlanoSemanal(frango);

            // Almoço
            var jantar = new RefeicaoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                tipo: "Jantar",
                ordem: 3,
                planoSemanalDiaId: segunda.Id
            );

            var batataDoce = new AlimentoPlanoSemanal(
                Guid.NewGuid().ToString(),
                "Batata Doce",
                gramas: 350,
                jantar.Id
            );

            var carne = new AlimentoPlanoSemanal(
                id: Guid.NewGuid().ToString(),
                "Patinho moído",
                gramas: 250,
                jantar.Id
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
