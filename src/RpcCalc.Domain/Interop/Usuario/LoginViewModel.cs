using System.ComponentModel.DataAnnotations;

namespace RpcCalc.Domain.Interop.Usuario
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }

        public string Sistema { get; set; } = null!;
    }
}
