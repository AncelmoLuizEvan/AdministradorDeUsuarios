using System.ComponentModel.DataAnnotations;

namespace RpcCalc.APP.Interop.Usuario
{
    public class UsuarioViewModel
    {
        [Required]
        public string CnpjCpf { get; set; } = null!;

        [Required]
        public string? Nome { get; set; } = null!;

        [Required]
        public string? Login { get; set; } = null!;

        [Required]
        public string? Email { get; set; } = null!;

        public string? Celular { get; set; } 
    }
}
