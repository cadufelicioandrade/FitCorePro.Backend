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

        public async Task<string> AdicionarRefeicaoPlanoSemanalAsync(string usuarioId, RefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            _context.RefeicoesPlanoSemanal.Add(refeicaoPlanoSemanal);

            var resutl = await _context.SaveChangesAsync();

            if (resutl > 0)
                return "Refeição adicionada com sucesso!";

            return "Falha ao tentar adicionar refeição.";
        }

        public async Task<string> RemoverRefeicaoPlanoSemanalAsync(string usuarioId, string refeicaoId)
        {
            var refeicao = await _context.RefeicoesPlanoSemanal
                .FirstOrDefaultAsync(x => 
                x.Id == refeicaoId 
                && x.PlanoSemanalDia.PlanoSemanal.UsuarioId == usuarioId);

            _context.RefeicoesPlanoSemanal.Remove(refeicao);
            var result = await _context.SaveChangesAsync();

            if (result > 0) 
                return "Refeição Excluída com Sucesso!";

            return "Falha ao tentar excluir a refeição.";
        }
    }
}
