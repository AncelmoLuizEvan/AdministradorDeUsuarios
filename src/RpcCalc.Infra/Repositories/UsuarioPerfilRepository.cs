using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.Repositories
{
    public class UsuarioPerfilRepository : Repository<UsuarioPerfilEntity>, IUsuarioPerfilRepository
    {
        public UsuarioPerfilRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
