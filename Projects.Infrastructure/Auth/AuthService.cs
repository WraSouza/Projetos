using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Projects.Infrastructure.Auth
{
    public class AuthService(IConfiguration configuration) : IAuthService
    {
        public string ComputeHash(string password)
        {
            using(var hash = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                var hashBytes = hash.ComputeHash(passwordBytes);

                var builder = new StringBuilder();

                for(int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string GenerateToken(string email, string role)
        {
            var issuer = configuration["Jwt:Issuer"];

            var audience = configuration["Jwt:Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var claims = new List<Claim>
            //{
            //    new Claim("username", email),
            //    new Claim(ClaimTypes.Role, role)
            //};

            var token = new JwtSecurityToken(issuer, audience, null, null, DateTime.Now.AddHours(2), credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
