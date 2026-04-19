using FitCorePro.Identity.Domain.Entities;
using FitCorePro.Identity.Domain.Repositories;
using FitCorePro.Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitCorePro.Identity.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IdentityDbContext _context;

        public UsuarioRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios
                .Include(x => x.RefreshTokens)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Usuario?> ObterPorIdAsync(string id)
        {
            return await _context.Usuarios
                .Include(x => x.RefreshTokens)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}