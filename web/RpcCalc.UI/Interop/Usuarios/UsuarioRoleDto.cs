using RpcCalc.UI.Interop.Roles;

namespace RpcCalc.UI.Interop.Usuarios
{
    public class UsuarioRoleDto
    {
        public Guid UsuarioId { get; set; }
        public Guid RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
