using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Stratio.Challenges.VehicleMaintenances.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _jwtKey = "My_Super_Awesome_Secret_Key_With_At_Least_32_Characters";

        public async Task<string> Login(string email, string password)
        {
            // The Mick
            // The condition below will be replaced by calling DBContext
            if (email == "claudia@stratio.com" && password == "stratio2024")
            {
                return GenerateJwtToken(email, "Org_Stratio_Internal");
            }

            return null; // Credenciais erradas
        }

        private string GenerateJwtToken(string email, string organizationId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("OrganizationId", organizationId) // A Claim que a Stratio valoriza
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
