using System.ComponentModel.DataAnnotations;

namespace RpcCalc.APP.Interop.Permissoes
{
    public class PermissaoViewModel
    {
        [Required(ErrorMessage = "O Nome do sistema é obrigatório")]
        public string Sistema { get; set; } = null!;

        public bool Acessar { get; set; } = false;

        [Required(ErrorMessage = "Um perfil vinculado a permissão é obrigatório")]
        public Guid PerfilId { get; set; }

        public string Perfil { get; set; } = null!;
    }
}
