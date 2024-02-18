using RpcCalc.Domain.Entities;

namespace RpcCalc.Domain.Interfaces.RepositoriesReadOnly
{
    public interface IUsuarioRepositoryReadOnly : IRepositoryReadOnly<UsuarioEntity>
    {
        Task<UsuarioEntity?> ObterPorLogin(string email);
        Task<UsuarioEntity?> ObterUsuarioTrocarStatus(Guid id);
    }
}
