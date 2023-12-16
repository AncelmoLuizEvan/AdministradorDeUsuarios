using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class UsuarioRoleRepositoryReadOnly : RepositoryReadOnly<UsuarioRoleEntity>, IUsuarioRoleRepositoryReadOnly
    {
        public UsuarioRoleRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }

        public async Task<UsuarioRoleEntity> CapiturarRoleDoUsuario(Guid usuarioId, Guid roleId)
        {
            var result = await _context.UsuarioRole!
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId && p.RoleId == roleId);

            return result!;
        }
    }
}
