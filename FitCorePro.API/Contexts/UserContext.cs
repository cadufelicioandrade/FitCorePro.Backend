using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FitCorePro.Identity.Application.Interfaces;

namespace FitCorePro.API.Contexts
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserId()
        {
            return "97cb3ea6-906e-420d-9ce4-ec426dd9f5c5";

                //return _httpContextAccessor.HttpContext?
                //    .User?
                //    .FindFirstValue(JwtRegisteredClaimNames.Sub);
        }

        public string? GetEmail()
        {
            return _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(JwtRegisteredClaimNames.Email);
        }

        public string? GetRole()
        {
            return _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.Role);
        }
    }
}