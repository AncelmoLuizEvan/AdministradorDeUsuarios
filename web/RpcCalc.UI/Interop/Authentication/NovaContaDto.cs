namespace RpcCalc.UI.Interop.Authentication
{
    public class NovaContaDto
    {
        public Guid Id { get; set; }
        public string CnpjCpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Celular { get; set; }
    }
}
