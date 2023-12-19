using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Authentication;

namespace RpcCalc.UI.Components.Pages.Logins
{
    public partial class Formulario
    {
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public LoginViewModel Model { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        protected void GoToLNovaConta() => Navigation.NavigateTo("/novaconta");
    }
}
