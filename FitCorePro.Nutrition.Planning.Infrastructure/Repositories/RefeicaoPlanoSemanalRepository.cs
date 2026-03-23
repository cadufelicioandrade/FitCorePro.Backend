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

        public async Task<string> AdicionarRefeicaoPlanoSemanalAsync(RefeicaoPlanoSemanal refeicaoPlanoSemanal)
        {
            //_context.RefeicoesPlanoSemanal.Add(refeicaoPlanoSemanal);

            var resutl = 1; //await _context.SaveChangesAsync();

            if (resutl > 0)
                return "Refeição adicionada com sucesso!";

            return "Falha ao tentar adicionar refeição.";
        }

        public async Task<string> RemoverRefeicaoPlanoSemanalAsync(string refeicaoId)
        {
            var result = 1;

            //var refeicao = await _context.RefeicoesPlanoSemanais
            //                        .FirstOrDefaultAsync(x => x.Id == refeicaoId);

            //_context.RefeicoesPlanoSemanais.Remove(refeicao);
            //var result = await _context.SaveChangesAsync();

            if (result > 0) return "Refeição Excluída com Sucesso!";
            return "Falha ao tentar excluir a refeição.";
        }
    }
}
