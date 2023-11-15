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
    }
}
