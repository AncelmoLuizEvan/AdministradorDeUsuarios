namespace RpcCalc.Domain.Entities
{
    public class UsuarioRoleEntity : BaseEntity
    {
        public UsuarioRoleEntity() { }

        public UsuarioRoleEntity(Guid usuarioId, Guid roleId)
        {
            UsuarioId = usuarioId;
            RoleId = roleId;
        }

        public Guid UsuarioId { get; private set; }
        public UsuarioEntity Usuario { get; set; }

        public Guid RoleId { get; private set; }
        public RoleEntity Role { get; set; }


    }
}
