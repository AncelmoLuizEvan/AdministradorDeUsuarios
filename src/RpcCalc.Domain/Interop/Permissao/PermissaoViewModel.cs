using System.ComponentModel.DataAnnotations;

namespace RpcCalc.Domain.Interop.Permissao
{
    public class PermissaoViewModel
    {
        [Required]
        public string Sistema { get; set; }
        public int Acessar { get; set; } = 0;
    }
}
