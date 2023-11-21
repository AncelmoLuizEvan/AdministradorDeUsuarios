using RpcCalc.Domain.Interop.Permissao;

namespace RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase
{
    public interface IPermissaoSearch
    {
        Task<IEnumerable<PermissaoDto>> Listar();
        Task<PermissaoDto?> Capturar(Guid id);
    }
}
