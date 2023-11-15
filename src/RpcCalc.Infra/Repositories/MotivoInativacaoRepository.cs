using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.Repositories
{
    public class MotivoInativacaoRepository : Repository<MotivoInativacaoEntity>, IMotivoInativacaoRepository
    {
        public MotivoInativacaoRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
