using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Interfaces.UseCases.RoleUseCase
{
    public interface IRoleSearch
    {
        Task<IEnumerable<RoleDto>> Listar();
    }
}
