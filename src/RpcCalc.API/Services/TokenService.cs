using Microsoft.IdentityModel.Tokens;
using RpcCalc.API.Configuration;
using RpcCalc.API.Extensions;
using RpcCalc.Domain.Interop.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RpcCalc.API.Services
{
    public class TokenService
    {
        public string GerarToken(LoginDto dto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthConfiguration.JwtKey);
            var claims = dto.ObterClaims();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
