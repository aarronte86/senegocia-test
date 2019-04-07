using System.ComponentModel.DataAnnotations;

namespace Senegocia.WebApi.Services.Auth
{
    public class LoginRequest
    {
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}
