using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class RoleRepositoryReadOnly : RepositoryReadOnly<RoleEntity>, IRoleRepositoryReadOnly
    {
        public RoleRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }
    }
}
