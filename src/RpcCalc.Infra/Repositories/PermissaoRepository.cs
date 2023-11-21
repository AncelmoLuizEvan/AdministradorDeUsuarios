using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.Repositories
{
    public class PermissaoRepository : Repository<PermissaoEntity>, IPermissaoRepository
    {
        public PermissaoRepository(DataBaseContext context) : base(context)
        {
        }        
    }
}
