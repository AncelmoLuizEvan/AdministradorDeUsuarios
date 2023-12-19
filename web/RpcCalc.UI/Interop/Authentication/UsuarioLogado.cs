namespace RpcCalc.UI.Interop.Authentication
{
    public class UsuarioLogado
    {
        public bool Sucesso { get; set; }
        public string? Error { get; set; }
        public string Token { get; set; } = string.Empty;
        public UsuarioInfo? Usuario { get; set; }
    }

    public class UsuarioInfo
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
