using RpcCalc.Domain.Interop.Usuario;
using System.Security.Claims;

namespace RpcCalc.API.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> ObterClaims(this LoginDto loginDto)
        {
            var result = new List<Claim>
            {
                new (ClaimTypes.Name, loginDto.Nome)
            };

            result.AddRange(loginDto.Roles.Select(role => new Claim(ClaimTypes.Role, role.Nome)));

            return result;
        }
    }
}
