using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.Repositories
{
    public class UsuarioRepository : Repository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
