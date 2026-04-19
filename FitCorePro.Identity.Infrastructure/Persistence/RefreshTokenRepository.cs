using FitCorePro.Identity.Domain.Entities;
using FitCorePro.Identity.Domain.Repositories;
using FitCorePro.Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Identity.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IdentityDbContext _context;

        public RefreshTokenRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken?> ObterPorTokenAsync(string token)
        {
            return await _context.RefreshTokens
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task AdicionarAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);
            await _context.SaveChangesAsync();
        }
    }
}