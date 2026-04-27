using FitCorePro.Nutrition.Planning.Domain.Entities;
using FitCorePro.Nutrition.Planning.Domain.Repositories;
using FitCorePro.Nutrition.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace FitCorePro.Nutrition.Planning.Infrastructure.Repositories
{
    public class RefeicaoPlanoSemanalRepository : IRefeicaoPlanoSemanalRepository
    {
        private readonly PlanningDbContext _context;

        public RefeicaoPlanoSemanalRepository(PlanningDbContext context)
        {
            _context = context;
        }

        public async Task<string> AdicionarRefeicaoPlanoSemanalAsync(string planoSemanalId,int diaSemana,RefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            var planoExiste = await _context.PlanosSemanal
                .AnyAsync(p => p.Id == planoSemanalId);

            if (!planoExiste)
                return "Plano semanal não encontrado.";

            var planoSemanalDia = await _context.PlanoSemanalDia
                .FirstOrDefaultAsync(d =>
                    d.PlanoSemanalId == planoSemanalId &&
                    d.DiaSemana == diaSemana);

            if (planoSemanalDia is null)
            {
                var planoSemanalDiaId = Guid.NewGuid().ToString();

                planoSemanalDia = new PlanoSemanalDia(
                    planoSemanalDiaId,
                    planoSemanalId,
                    diaSemana,
                    DateTime.UtcNow);

                _context.PlanoSemanalDia.Add(planoSemanalDia);

                refeicaoPlanoSemanal.PlanoSemanalDiaId = planoSemanalDiaId;
            }
            else
            {
                refeicaoPlanoSemanal.PlanoSemanalDiaId = planoSemanalDia.Id;
            }

            _context.RefeicoesPlanoSemanal.Add(refeicaoPlanoSemanal);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Refeição adicionada com sucesso!";

            return "Falha ao tentar adicionar refeição.";
        }

        public async Task<string> RemoverRefeicaoPlanoSemanalAsync(string refeicaoId)
        {
            var refeicao = await _context.RefeicoesPlanoSemanal
                .FirstOrDefaultAsync(x => 
                x.Id == refeicaoId);

            if (refeicao == null)
                return "Refeição não localizada.";

            _context.RefeicoesPlanoSemanal.Remove(refeicao);
            var result = await _context.SaveChangesAsync();

            if (result > 0) 
                return "Refeição Excluída com Sucesso!";

            return "Falha ao tentar excluir a refeição.";
        }
    }
}
