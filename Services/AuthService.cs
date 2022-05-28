using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AllAboutGames.Services
{
    public class AuthService
    {
        private readonly string Secret;

        public AuthService(string secret)
        {
            this.Secret = secret;
        }

        public string GenerateJwtToken(long id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.UtcNow.AddDays(7));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
