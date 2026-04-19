using FitCorePro.Identity.Application.Contracts.Requests;
using FitCorePro.Identity.Application.Contracts.Responses;

namespace FitCorePro.Identity.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegistrarAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);
        Task LogoutAsync(string refreshToken);
    }
}