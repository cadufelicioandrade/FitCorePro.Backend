using FitCorePro.Training.Planning.Domain.Entities;
using FitCorePro.Training.Planning.Domain.Repositories;
using FitCorePro.Training.Planning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Training.Planning.Infrastructure.Repositories
{
    public class PlanoTreinoSemanalRepository : IPlanoTreinoSemanalRepository
    {
        public TraniningDbContext _contex;

        public PlanoTreinoSemanalRepository(TraniningDbContext contex)
        {
            _contex = contex;
        }

        public async Task<string> AdicionarPlanoSemanalAsync(PlanoTreinoSemanal planoTreinoSemanal)
        {
            var listPlanoAtivo = await _contex.PlanoTreinoSemanal.Where(p => p.Ativo && p.UsuarioId == planoTreinoSemanal.UsuarioId).ToListAsync();

            if (listPlanoAtivo.Count > 0)
            {
                listPlanoAtivo.ForEach(p => 
                {
                    p.Ativo = false;
                });
                _contex.PlanoTreinoSemanal.UpdateRange(listPlanoAtivo);
            }

            _contex.PlanoTreinoSemanal.Add(planoTreinoSemanal);
            var result = await _contex.SaveChangesAsync();

            if (result > 0)
                return "Plano treino semanal adicionado com sucesso!";

            return "Não foi possível realizar a operção, tente novamente mais tarde.";
        }

        public async Task<string> AtualizarPlanoSemanalAsync(PlanoTreinoSemanal planoTreinoSemanal)
        {
            var plano = await _contex.PlanoTreinoSemanal.Where(x => x.UsuarioId == planoTreinoSemanal.UsuarioId && x.Id == planoTreinoSemanal.Id).FirstOrDefaultAsync();

            if (plano == null)
                return "Plano não encontrado.";

            /// TODO
            /// fazer o depara das propriedade para atualizar o plano

            _contex.PlanoTreinoSemanal.Update(planoTreinoSemanal);
            var result = await _contex.SaveChangesAsync();

            if (result > 0)
                return "Plano treino semanal atualizado com sucesso!";

            return "Não foi possível realizar a operção, tente novamente mais tarde.";
        }

        public async Task<PlanoTreinoSemanal?> ObterPlanoTreinoSemanalAsync(string usuarioId)
        {
            var result = await _contex.PlanoTreinoSemanal
                            .Include(p => p.TreinosDia)
                            .ThenInclude(t => t.Exercicios)
                                .Where(p => p.Ativo && p.UsuarioId == usuarioId)
                                    .FirstOrDefaultAsync();

            return result;
        }
    }
}
