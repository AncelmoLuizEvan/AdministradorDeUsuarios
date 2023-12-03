using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class PermissaoRepositoryReadOnly : RepositoryReadOnly<PermissaoEntity>, IPermissaoRepositoryReadOnly
    {
        public PermissaoRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }

        public override async Task<PermissaoEntity?> Capturar(Guid id)
        {
            var result = await _context.Permissao!
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public override async Task<IEnumerable<PermissaoEntity>?> Listar()
        {
            var result = await _context.Permissao!
               .Include(p => p.Perfil)
               .AsNoTracking()
               .ToListAsync();

            return result;
        }
    }
}
