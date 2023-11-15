using System.ComponentModel.DataAnnotations;

namespace RpcCalc.Domain.Interop.Perfil
{
    public class PerfilViewModel
    {
        [Required]
        public string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
