namespace RpcCalc.Domain.Interop.Usuario
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
