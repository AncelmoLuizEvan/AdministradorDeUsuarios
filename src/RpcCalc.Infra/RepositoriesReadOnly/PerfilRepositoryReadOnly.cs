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
    }
}
