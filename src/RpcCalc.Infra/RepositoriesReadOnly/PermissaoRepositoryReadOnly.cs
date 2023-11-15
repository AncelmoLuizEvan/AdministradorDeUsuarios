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
    }
}
