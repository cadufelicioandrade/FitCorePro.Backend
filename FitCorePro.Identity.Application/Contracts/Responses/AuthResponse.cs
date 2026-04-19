namespace FitCorePro.Identity.Application.Contracts.Responses
{
    public class AuthResponse
    {
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string UsuarioId { get; internal set; }
    }
}