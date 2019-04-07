using System.ComponentModel.DataAnnotations;

namespace Senegocia.WebApi.Services.Auth
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}
