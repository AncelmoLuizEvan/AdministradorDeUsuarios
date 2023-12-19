using System.ComponentModel.DataAnnotations;

namespace RpcCalc.UI.Interop.Authentication
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O login é um e-mail e é obrigatório")]
        [EmailAddress(ErrorMessage ="Inclua um e-mail válido!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
