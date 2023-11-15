namespace RpcCalc.Domain.Entities
{
    public class UsuarioPerfilEntity : BaseEntity
    {
        public UsuarioPerfilEntity() { }

        public Guid UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; } = new UsuarioEntity();
        public Guid PerfilId { get; set; }
        public PerfilEntity Perfil { get; set; } = new PerfilEntity();
    }
}
