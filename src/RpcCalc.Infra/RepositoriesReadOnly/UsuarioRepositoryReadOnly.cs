using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class UsuarioRepositoryReadOnly : RepositoryReadOnly<UsuarioEntity>, IUsuarioRepositoryReadOnly
    {
        public UsuarioRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }

        public override async Task<UsuarioEntity?> Capturar(Guid id)
        {
            var result = await _context.Usuario!
                .AsNoTracking()
                .Include(u => u.UsuarioPerfis)
                    .ThenInclude(x => x.Perfil)
                .Include(u => u.Roles)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task<UsuarioEntity?> ObterPorLogin(string email)
        {
            var result = await _context.Usuario!
                .AsNoTracking()
                .Include(u => u.Roles)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            return result;
        }
    }
}
