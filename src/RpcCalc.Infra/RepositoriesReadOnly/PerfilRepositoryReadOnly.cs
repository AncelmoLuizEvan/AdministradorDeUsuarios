using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class PerfilRepositoryReadOnly : RepositoryReadOnly<PerfilEntity>, IPerfilRepositoryReadOnly
    {
        public PerfilRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }

        public override async Task<PerfilEntity?> Capturar(Guid id)
        {
            var result = await _context.Perfil!
                .Include(p => p.Permissoes)
                .FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }
    }
}
