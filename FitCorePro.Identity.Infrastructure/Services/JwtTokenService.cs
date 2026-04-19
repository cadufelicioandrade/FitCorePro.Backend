using FitCorePro.Identity.Application.Configuration;
using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Identity.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FitCorePro.Identity.Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly AuthConfig _authConfig;

        public JwtTokenService(IOptions<AuthConfig> authConfig)
        {
            _authConfig = authConfig.Value;
        }

        public string GerarAccessToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, usuario.Id),
                new(JwtRegisteredClaimNames.Email, usuario.Email),
                new(ClaimTypes.Name, usuario.Nome),
                new(ClaimTypes.Role, usuario.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authConfig.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _authConfig.Issuer,
                audience: _authConfig.Audience,
                claims: claims,
                expires: ObterExpiracaoAccessToken(),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GerarRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes);
        }

        public DateTime ObterExpiracaoAccessToken()
        {
            return DateTime.UtcNow.AddMinutes(_authConfig.AccessTokenMinutes);
        }

        public DateTime ObterExpiracaoRefreshToken()
        {
            return DateTime.UtcNow.AddDays(_authConfig.RefreshTokenDays);
        }
    }
}