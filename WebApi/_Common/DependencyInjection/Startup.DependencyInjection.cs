using Microsoft.Extensions.DependencyInjection;

using Senegocia.WebApi.Services.Auth;

namespace Senegocia.WebApi
{
    public partial class Startup
    {
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddOptions();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
        }
    }
}
