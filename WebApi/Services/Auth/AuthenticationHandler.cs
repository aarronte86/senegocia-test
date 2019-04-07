using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Senegocia.WebApi.Entities;

namespace Senegocia.WebApi.Services.Auth
{
    public interface IAuthenticationHandler
    {
        Task<string> HandleLogin(LoginRequest request);
    }

    public class AuthenticationHandler : IAuthenticationHandler
    {
        private readonly IJwtProvider _jwtGenerator;

        private readonly IEnumerable<User> _usersAllowed;

        public AuthenticationHandler(IJwtProvider jwtProvider)
        {
            this._usersAllowed = new List<User>
            {
                User.Create("Alfredo", "Arronte Ameneiro", "aarronte86@gmail.com", "aarronte123"),
                User.Create("Rafael", "Cid Botteselle", "rafael.cid@gmail.com", "rafael123")
            };

            this._jwtGenerator = jwtProvider;
        }

        public async Task<string> HandleLogin(LoginRequest request)
        {
            string tokenString = null;

            User user = this._usersAllowed.FirstOrDefault(u => u.Email == request.UserEmail && u.Password == request.UserPassword);

            if (user != null)
            {
                tokenString = await this._jwtGenerator.GenerateToken(user);
            }

            return tokenString;            
        }
    }
}
