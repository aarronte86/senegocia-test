using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Senegocia.WebApi.Entities;

namespace Senegocia.WebApi.Services.Auth
{
    public interface IJwtProvider
    {
        Task<string> GenerateToken(User user);
    }

    public class JwtProvider : IJwtProvider
    {
        private readonly IJwtOptions _jwtOptions;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtProvider(IOptions<JwtOptions> jwtOptions)
        {
            this._jwtOptions = jwtOptions.Value;
            this._tokenHandler = new JwtSecurityTokenHandler();
        }

        public Task<string> GenerateToken(User user)
        {
            return Task.Run(() => 
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtOptions.SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                  this._jwtOptions.Issuer,
                  this._jwtOptions.Issuer,
                  null,
                  expires: DateTime.Now.AddMinutes(this._jwtOptions.ExpireIn),
                  signingCredentials: credentials);
                
                return this._tokenHandler.WriteToken(token);
            });
        }        
    }
}
