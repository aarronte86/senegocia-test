using Microsoft.Extensions.DependencyInjection;

using Senegocia.WebApi.Services.Auth;
using Senegocia.WebApi.Services.Indicator;
using Senegocia.WebApi.Services.Integration.Indicators;

namespace Senegocia.WebApi
{
    public partial class Startup
    {
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddOptions();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();

            services.AddScoped<IIndicatorsService, IndicatorsService>();
            services.AddScoped<IIndicatorsOutputHandler, IndicatorsOutputHandler>();
        }
    }
}
