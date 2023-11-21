using RpcCalc.Domain.Interop.Permissao;

namespace RpcCalc.Domain.Interop.Perfil
{
    public class PerfilDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }

        public IEnumerable<PermissaoDto>? Permissoes { get; set; }
    }
}
