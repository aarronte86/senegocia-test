using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Senegocia.WebApi.Services.Auth;

namespace Senegocia.WebApi.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationHandler _authHandler;

        public AuthController(IAuthenticationHandler authHandler)
        {
            this._authHandler = authHandler;
        }

        // Generates token
        [AllowAnonymous]
        [Route("token")]
        [HttpPost]
        public async Task<IActionResult> GenerateToken([FromBody]LoginRequest request)
        {
            string token = await this._authHandler.HandleLogin(request);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
