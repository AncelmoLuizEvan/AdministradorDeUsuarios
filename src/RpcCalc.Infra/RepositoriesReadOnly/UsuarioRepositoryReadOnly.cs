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
                .FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task<UsuarioEntity?> ObterPorLogin(string email)
        {
          var result = await _context.Usuario!
                 .AsNoTracking()
                 .Include(r => r.Roles)
                 .FirstOrDefaultAsync(u => u.Email == email);

            return result;
        }
    }
}
