using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class MotivoInativacaoRepositoryReadOnly : RepositoryReadOnly<MotivoInativacaoEntity>, IMotivoInativacaoRepositoryReadOnly
    {
        public MotivoInativacaoRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MotivoInativacaoEntity>> ListarPorUsuario(Guid usuarioId)
        {
            var result = await _context.Set<MotivoInativacaoEntity>()
                .AsNoTracking()
                .Where(x => x.UsuarioId == usuarioId).ToListAsync();

            return result;
        }
    }
}
