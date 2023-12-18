using System.ComponentModel.DataAnnotations;

namespace RpcCalc.UI.Interop.Authentication
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
