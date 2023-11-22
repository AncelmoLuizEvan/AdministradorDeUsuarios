namespace RpcCalc.Domain.Interop.MotivoInativacao
{
    public class MotivoInativacaoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = null!;
        public Guid UsuarioId { get; set; }
    }
}
