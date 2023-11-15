using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class UsuarioPerfilRepositoryReadOnly : RepositoryReadOnly<UsuarioPerfilEntity>, IUsuarioPerfilRepositoryReadOnly
    {
        public UsuarioPerfilRepositoryReadOnly(DataBaseContext context) : base(context)
        {
        }
    }
}
