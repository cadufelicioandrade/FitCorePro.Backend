using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Identity.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FitCorePro.Identity.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
