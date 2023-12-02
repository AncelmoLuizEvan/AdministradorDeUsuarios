using RpcCalc.Domain.Interop.Perfil;

namespace RpcCalc.Domain.Interop.Permissao
{
    public class PermissaoDto
    {
        public Guid Id { get; set; }
        public string Sistema { get; set; } = null!;
        public bool Acessar { get; set; }
        public Guid PerfilId { get; set; }
        public PerfilDto Perfil { get; set; } = null!;
    }
}
