namespace RpcCalc.Domain.Entities
{
    public class MotivoInativacaoEntity : BaseEntity
    {
        public MotivoInativacaoEntity() { }

        public MotivoInativacaoEntity(string descricao, Guid usuarioId)
        {
            Descricao = descricao;
            UsuarioId = usuarioId;
        }

        public string Descricao { get; private set; } = null!;
        public Guid UsuarioId { get; private set; }
        public UsuarioEntity Usuario { get; set; }
    }
}
