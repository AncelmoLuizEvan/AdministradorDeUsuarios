using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.Repositories
{
    public class UsuarioRoleRepository : Repository<UsuarioRoleEntity>, IUsuarioRoleRepository
    {
        public UsuarioRoleRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
