using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Authentication;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Services.Authentication;
using RpcCalc.UI.Services.Usuarios;

namespace RpcCalc.UI.Components.Pages.Logins
{
    public partial class Login
    {
        [Inject]
        private IAuthService Service { get; set; } = null!;

        [Inject]
        private IUsuarioService UsuarioService { get; set; } = null!;

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        LoginViewModel LoginVM = new LoginViewModel();
   
        private string Error = string.Empty;

        private Guid? Id { get; set; }

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        private async Task FazerLogin()
        {
            var result = await Service.Login(LoginVM);

            if (result.Sucesso)
            {
                if (!string.IsNullOrWhiteSpace(result.Usuario!.Role))
                {
                    var buscarPorEmail = new EmailViewModel
                    {
                        Email = result.Usuario.Email
                    };

                    var usuarioDto = await UsuarioService.ObterPorEmail(buscarPorEmail);

                    Navigation.NavigateTo($"/usuario/cliente/details/{usuarioDto!.Id}");
                }
                else
                {
                    Navigation.NavigateTo("/admin");
                }
            }
            else
            {
                Error = result.Error!;
            }
        }


    }
}
