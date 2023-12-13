namespace RpcCalc.Domain.Entities
{
    public class UsuarioPerfilEntity : BaseEntity
    {
        public UsuarioPerfilEntity() { }

        public UsuarioPerfilEntity(Guid usuarioId, Guid perfilId, DateTime dataInicio, DateTime? dataFinal)
        {
            UsuarioId = usuarioId;
            PerfilId = perfilId;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
        }

        public Guid UsuarioId { get; private set; }
        public UsuarioEntity Usuario { get; set; } = new UsuarioEntity();
        public Guid PerfilId { get; private set; }
        public PerfilEntity Perfil { get; set; } = new PerfilEntity();

        public DateTime DataInicio { get; private set; }
        public DateTime? DataFinal { get; private set; }
    }
}
