namespace RpcCalc.UI.Interop.Usuarios
{
    public class UsuarioPerfilDto
    {
        public Guid UsuarioId { get; set; }
        public Guid PerfilId { get; set; }
        public Guid PermissaoId { get; set; }

        public string Perfil { get; set; } = string.Empty;
        public string Permissao { get; set; } = string.Empty;
    }
}
