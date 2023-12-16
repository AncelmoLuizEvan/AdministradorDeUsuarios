namespace RpcCalc.Domain.Interop.Usuario
{
    public class UsuarioRoleDto
    {
        public Guid UsuarioId { get; set; }
        public Guid RoleId { get; set; }

        public RoleDto Role { get; set; }
    }
}
