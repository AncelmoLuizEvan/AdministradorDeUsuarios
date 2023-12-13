namespace RpcCalc.Domain.Interop.Usuario
{
    public class UsuarioPerfilDto
    {
        public Guid UsuarioId { get; set; }
        public Guid PerfilId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public string Perfil { get; set; } = string.Empty;
        public string Permissao { get; set; } = string.Empty;
    }
}
