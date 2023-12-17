using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Authentication;
using RpcCalc.UI.Services.Authentication;

namespace RpcCalc.UI.Components.Pages.Logins
{
    public partial class Login
    {
        [Inject]
        private IAuthService Service { get; set; } = null!;

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        LoginViewModel LoginVM = new LoginViewModel();
        private bool ShowErrors;
        private string Error = string.Empty;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        private async Task FazerLogin()
        {
            ShowErrors = false;

            var result = await Service.Login(LoginVM);

            if (result.Sucesso)
            {
                Navigation.NavigateTo("/");
            }
            else
            {
                Error = result.Error!;
                ShowErrors = true;

                Navigation.NavigateTo("/login");
            }
        }
    }
}
