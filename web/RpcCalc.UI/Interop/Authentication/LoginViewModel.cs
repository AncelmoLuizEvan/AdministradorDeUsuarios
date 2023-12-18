using System.ComponentModel.DataAnnotations;

namespace RpcCalc.UI.Interop.Authentication
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O login é um e-mail válido e é obrigatório")]
        [EmailAddress]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
