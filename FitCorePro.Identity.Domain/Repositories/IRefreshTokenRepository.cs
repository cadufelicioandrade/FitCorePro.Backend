using FitCorePro.Identity.Domain.Entities;

namespace FitCorePro.Identity.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task AdicionarAsync(RefreshToken refreshToken);
        Task<RefreshToken?> ObterPorTokenAsync(string token);
        Task AtualizarAsync(RefreshToken refreshToken);
    }
}