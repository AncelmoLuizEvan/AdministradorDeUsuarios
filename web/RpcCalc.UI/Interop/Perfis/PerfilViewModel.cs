using System.ComponentModel.DataAnnotations;

namespace RpcCalc.UI.Interop.Perfis
{
    public class PerfilViewModel
    {
        [Required(ErrorMessage = "O Nome do perfil é obrigatório")]
        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }
    }
}
