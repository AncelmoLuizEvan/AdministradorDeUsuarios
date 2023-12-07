using RpcCalc.UI.Interop.Permissoes;

namespace RpcCalc.UI.Interop.Perfis
{
    public class PerfilDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }

        public IEnumerable<PermissaoDto> Permissoes { get; set;}
    }
}
