namespace FitCorePro.Identity.Application.Contracts.Requests
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; } = default!;
    }
}