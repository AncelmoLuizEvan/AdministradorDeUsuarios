using System.ComponentModel.DataAnnotations;

namespace RpcCalc.APP.Interop.Perfil
{
    public class PerfilViewModel
    {
        [Required(ErrorMessage = "O Nome do perfil é obrigatório")]
        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }
    }
}
