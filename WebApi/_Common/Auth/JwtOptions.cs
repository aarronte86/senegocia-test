namespace Senegocia.WebApi
{
    public interface IJwtOptions
    {
        string SecretKey { get; }

        string Issuer { get; }

        int ExpireIn { get; }
    }

    public class JwtOptions : IJwtOptions
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public int ExpireIn { get; set; }
    }
}
