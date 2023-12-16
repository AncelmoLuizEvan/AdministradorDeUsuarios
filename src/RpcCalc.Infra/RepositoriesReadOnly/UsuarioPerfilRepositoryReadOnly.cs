using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class UsuarioPerfilRepositoryReadOnly : RepositoryReadOnly<UsuarioPerfilEntity>, IUsuarioPerfilRepositoryReadOnly
    {
        public UsuarioPerfilRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UsuarioPerfilEntity>> CapiturarPorUsuario(Guid usuarioId)
        {
            var result = await _context.UsuarioPerfil!
                .Include(p => p.Perfil)
                .Include(p => p.Permissao)
                .Include(p => p.Usuario)
                .AsNoTracking()
                .Where(p => p.UsuarioId == usuarioId)
                .ToListAsync();

            return result;
        }

        public async Task<UsuarioPerfilEntity> CapiturarPermissaoDoUsuario(Guid usuarioId, Guid perfilId, Guid permissaoId)
        {
            var result = await _context.UsuarioPerfil!
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId && p.PerfilId == perfilId && p.PermissaoId == permissaoId);

            return result!;
        }
    }
}
