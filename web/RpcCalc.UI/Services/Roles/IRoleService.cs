using RpcCalc.UI.Interop.Roles;

namespace RpcCalc.UI.Services.Roles
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>?> ObterTodos();
    }
}
