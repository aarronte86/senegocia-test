using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Senegocia.WebApi
{
    public partial class Startup
    {
        private void ConfigureAuthServices(IServiceCollection services)
        {
            // Get jwt options from app settings
            var jwtOptions = Configuration.GetSection("Jwt");
            services.Configure<JwtOptions>(jwtOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions["Issuer"],
                        ValidAudience = jwtOptions["Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions["SecretKey"]))
                    };
                });
        }

        private void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
