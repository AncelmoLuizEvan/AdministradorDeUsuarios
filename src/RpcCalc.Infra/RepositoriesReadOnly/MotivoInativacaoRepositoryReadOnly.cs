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

        public async Task<IEnumerable<MotivoInativacaoEntity>> CapturarPorDescricao(string descricao)
        {
            return await _context.Set<MotivoInativacaoEntity>()
                .Where(x => x.Descricao.Contains(descricao)).ToListAsync();
        }
    }
}
