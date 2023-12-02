namespace RpcCalc.Domain.Entities
{
    public class UsuarioPerfilEntity : BaseEntity
    {
        public UsuarioPerfilEntity() { }

        public UsuarioPerfilEntity(DateTime dataInicio, DateTime? dataFinal)
        {
            DataInicio = dataInicio;
            DataFinal = dataFinal;
        }

        public Guid UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; } = new UsuarioEntity();
        public Guid PerfilId { get; set; }
        public PerfilEntity Perfil { get; set; } = new PerfilEntity();

        public DateTime DataInicio { get; private set; }
        public DateTime? DataFinal { get; private set; }
    }
}
