using FitCorePro.Identity.Domain.Entities;

namespace FitCorePro.Identity.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GerarAccessToken(Usuario usuario);
        string GerarRefreshToken();
        DateTime ObterExpiracaoAccessToken();
        DateTime ObterExpiracaoRefreshToken();
    }
}