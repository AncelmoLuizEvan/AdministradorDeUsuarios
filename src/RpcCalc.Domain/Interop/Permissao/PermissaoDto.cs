namespace RpcCalc.Domain.Interop.Permissao
{
    public class PermissaoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool Acessar { get; set; }
    }
}
