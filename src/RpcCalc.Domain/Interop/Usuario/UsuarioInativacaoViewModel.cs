namespace RpcCalc.Domain.Interop.Usuario
{
    public class UsuarioInativacaoViewModel
    {
        public Guid UsuarioId { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public bool Inativo { get; set; }
    }
}
