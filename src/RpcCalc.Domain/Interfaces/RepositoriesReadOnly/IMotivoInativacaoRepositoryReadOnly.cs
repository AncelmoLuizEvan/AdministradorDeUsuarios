using RpcCalc.Domain.Entities;

namespace RpcCalc.Domain.Interfaces.RepositoriesReadOnly
{
    public interface IMotivoInativacaoRepositoryReadOnly : IRepositoryReadOnly<MotivoInativacaoEntity>
    {
        Task<IEnumerable<MotivoInativacaoEntity>> ListarPorUsuario(Guid usuarioId);

    }
}
