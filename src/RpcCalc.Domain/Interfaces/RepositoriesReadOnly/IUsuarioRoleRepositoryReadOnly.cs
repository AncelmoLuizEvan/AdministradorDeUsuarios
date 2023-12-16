using RpcCalc.Domain.Entities;

namespace RpcCalc.Domain.Interfaces.RepositoriesReadOnly
{
    public interface IUsuarioRoleRepositoryReadOnly : IRepositoryReadOnly<UsuarioRoleEntity>
    {
        Task<UsuarioRoleEntity> CapiturarRoleDoUsuario(Guid usuarioId, Guid roleId);
    }
}
