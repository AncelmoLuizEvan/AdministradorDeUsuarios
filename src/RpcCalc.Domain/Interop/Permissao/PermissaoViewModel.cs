using System.ComponentModel.DataAnnotations;

namespace RpcCalc.Domain.Interop.Permissao
{
    public class PermissaoViewModel
    {
        [Required(ErrorMessage = "O Nome do perfil é obrigatório")]
        public string Sistema { get; set; } = null!;

        public bool Acessar { get; set; } = false;

        [Required(ErrorMessage = "Um perfil vinculado a permissão é obrigatório")]
        public Guid PerfilId { get; set; }
    }
}
